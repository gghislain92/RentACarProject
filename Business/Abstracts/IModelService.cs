using Business.Dtos.Request;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IModelService{
        
        List<Model> GetAll();

        List<Model> GetAll(string modelName);

        void Add(CreateModelRequest createModelRequest);
    }
}
