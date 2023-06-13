using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
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
        ModelBusinessRules1 rules1;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
            rules = new ModelBusinessRules(_modelDal);
            rules1 = new ModelBusinessRules1(_modelDal);
        }

        public void Add(CreateModelRequest createModelRequest)
        {
            rules.ModelNameCanNotBeDuplicated(createModelRequest.Name);

            Model model = new Model
            {
                Name = createModelRequest.Name,
                DailyPrice = createModelRequest.dailyPrice,
                BrandId = createModelRequest.BrandId
            };
            _modelDal.Add(model);
        }

        public void Detele(DeleteModelRequest deleteModelRequest)
        {
            rules1.ModelIdCanNotBeFound(deleteModelRequest.Name);

            Model model = _modelDal.Get(n => n.Name == deleteModelRequest.Name);

            _modelDal.Delete(model);
        }

        public List<GetModelResponse> GetAll()
        {
            List<Model> model = _modelDal.GetList().ToList();
            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();
            foreach (Model model in models)
            {
                GetModelResponse modelResponse = new GetModelResponse();
                getModelResponses.Name = model.Name;
                getModelResponses.DailyPrice = model.DailyPrice;
                getModelResponses.Id = model.Id;
                getModelResponses.BrandId = model.BrandId;
                getModelResponses.BrandName = model.BrandName;

                getModelResponses.Add(getModelResponses);

            }

            return getModelResponses;
        }

        public List<GetModelResponse> GetAll(string modelName)
        {
            List<Model> model = _modelDal.GetList(m=>m.Name.ToLower().Contains(modelName.ToLower)).ToList();
            List<GetModelResponse> getModelResponses = new List<GetModelResponse>();
            foreach (Model model in models)
            {
                GetModelResponse modelResponse = new GetModelResponse();
                getModelResponses.Name = model.Name;
                getModelResponses.DailyPrice = model.DailyPrice;
                getModelResponses.Id = model.Id;
                getModelResponses.BrandId = model.BrandId;
                getModelResponses.BrandName = model.BrandName;

                getModelResponses.Add(getModelResponses);

            }

            return getModelResponses;
        }

        public void Update(UpdateModelRequest updateModelRequest)
        {
            Model model = _modelDal.Get(m => m.Name == updateModelRequest.Name);

            rules.ModelNameCanNotBeDuplicated(updateModelRequest.Name);

            model.Name = updateModelRequest.Name;
            model.DailyPrice = updateModelRequest.dailyPrice;

            _modelDal.Update(model);
        }
    }
}
