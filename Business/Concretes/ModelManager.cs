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
                DailyPrice = createModelRequest.dailyPrice,
                BrandId = createModelRequest.BrandId

            };
            _modelDal.Add(model);
        }
        public Model GetById(int modelId)
        {
            return _modelDal.Get(m => m.Id == modelId);
        }
        public List<Model> GetAll()
        {

            return _modelDal.GetList().ToList();
        }

        public List<Model> GetAll(string modelName)
        {
            return _modelDal.GetList(m => m.Name.Contains(modelName)).ToList();
        }

        public void update(UpdateModelRequest updateModelRequest)
        {
            rules.ModelNameCanNotBeDuplicated(updateModelRequest.Name);

            Model model = _modelDal.Get(m => m.Id == updateModelRequest.BrandId);
            if (model != null)
            {
                model.Name = updateModelRequest.Name;
                model.DailyPrice = updateModelRequest.dailyPrice;
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
