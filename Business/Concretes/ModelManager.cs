using Business.Abstracts;
using Business.Dtos.Request;
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
            rules1.ModelIdCanNotBeFound(deleteModelRequest.Id);

            Model model = _modelDal.Get(m => m.Id == deleteModelRequest.Id);

            _modelDal.Delete(model);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetList().ToList();
        }

        public List<Model> GetAll(string modelName)
        {
            return _modelDal.GetList(m => m.Name.Contains(modelName)).ToList();
        }

        public List<Model> GetAll(int modelId)
        {
            return _modelDal.GetList(m => m.Id.ToString().Contains(modelId.ToString())).ToList();
        }

        public void Update(UpdateModelRequest updateModelRequest)
        {
            Model model = _modelDal.Get(m => m.Id == (int)updateModelRequest.Id);

            rules.ModelNameCanNotBeDuplicated(updateModelRequest.Name);

            model.Name = updateModelRequest.Name;
            model.DailyPrice = updateModelRequest.dailyPrice;

            _modelDal.Update(model);
        }
    }
}
