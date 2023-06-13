using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Responses;
using Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ModelManager : IModelService
    {

        //dependency injection
        private IModelDal _modelDal;
        ModelBusinessRules rules;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
            rules = new ModelBusinessRules(_modelDal);
        }

        public void Add(CreateModelRequest createModelRequest)
        {
            //business analyst
            //model names can not be duplicated


            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);

            //spaghetti
            //reusibility


            //mapping
            Model model = new Model
            {
                Name = createModelRequest.Name,
                BrandId = createModelRequest.BrandId
            };
            _modelDal.Add(model);


            //try-catch
            //if
        }

        public List<GetModelResponse> GetAll()
        {

            //business rules
            List<Model> models = _modelDal.GetAllWithBrand().ToList();

            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();

            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

                getModelResponses.Add(getModelResponse);
            }

            return getModelResponses;

        }

        public List<GetModelResponse> GetAll(string modelName)
        {
            List<Model> models =
                _modelDal.GetAllWithBrand(modelName).ToList();


            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

                getModelResponses.Add(getModelResponse);
            }

            return getModelResponses;
        }
    }
}