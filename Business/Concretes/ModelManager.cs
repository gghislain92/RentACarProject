using Business.Abstracts;
using Business.Dtos.Request;
using Data_Access.Abstracts;
using Data_Access.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ModelManager : IModelService
    {

        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void Add(CreateModelRequest createModelRequest)
        {
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
            return _modelDal.GetList(b=>b.Name.Contains(modelName)).ToList();
        }
    }
}
