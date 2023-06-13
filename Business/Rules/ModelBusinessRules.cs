using Data_Access.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ModelBusinessRules
    {
        IModelDal _modelDal;

        public ModelBusinessRules(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }


        public void ModelNameCanNotBeDuplicated(string modelName)
        {
            Model? model = _modelDal.Get(m => m.Name == modelName);

            if (model != null)
            {
                throw new Exception("Model name already exists");
            }
        }
    }
}