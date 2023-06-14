using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Responses;
using Business.Rules;
using Data_Access.Abstracts;
using Data_Access.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ModelManager : IModelService
    {

        private IModelDal _modelDal;
        ModelBusinessRules rules;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
            rules = new ModelBusinessRules(_modelDal);
        }

        public void Add(CreateModelRequest createModelRequest)
        {
            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);

            Model model = new Model
            {
                Name = createModelRequest.Name,
                dailyPrice = createModelRequest.dailyPrice,
                BrandId = createModelRequest.BrandId
            };
            _modelDal.Add(model);
        }
        public Model GetById(int modelId)
        {
            return _modelDal.Get(m => m.Id == modelId);
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
                getModelResponse.dailyPrice = model.dailyPrice;
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

            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();

            foreach (Model model in models)
            {
                GetModelResponse getModelResponse = new GetModelResponse();
                getModelResponse.Name = model.Name;
                getModelResponse.dailyPrice = model.dailyPrice;
                getModelResponse.Id = model.Id;
                getModelResponse.BrandId = model.BrandId;
                getModelResponse.BrandName = model.Brand.Name;

                getModelResponses.Add(getModelResponse);
            }

            return getModelResponses;
        }


        public void update(UpdateModelRequest updateModelRequest)
        {
            rules.ModelNameCanNotBeDuplicated(updateModelRequest.Name);

            Model model = _modelDal.Get(m => m.Id == updateModelRequest.BrandId);
            if (model != null)
            {
                model.Name = updateModelRequest.Name;
                model.dailyPrice = updateModelRequest.dailyPrice;
                model.BrandId = updateModelRequest.BrandId;
                _modelDal.Update(model);
            }
        }
        public void delete(DeleteModelRequest deleteModelRequest)
        {
            Model model = _modelDal.Get(m => m.Id == deleteModelRequest.BrandId);
            _modelDal.Delete(model);
        }
    }
}
