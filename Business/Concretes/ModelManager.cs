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

        public List<Model> GetAll(){

            return _modelDal.GetList().ToList();
        }

        public List<Model> GetAll(string modelName)
        {
            return _modelDal.GetList(m=>m.Name.Contains(modelName)).ToList();
        }
    }
}
