using Business.Dtos.Request;
using Data_Access.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ModelBusinessRules1
    {
        IModelDal _modelDal;

        public ModelBusinessRules1(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }


        public void ModelIdCanNotBeFound(int modelId)
        {
            Model? model = _modelDal.Get(m => m.Id == modelId);

            if (model == null)
            {
                throw new ArgumentException("No model found with the id");
            }
        }
    }
}
