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

        List<Model> GetAll(int modelId);

        void Add(CreateModelRequest createModelRequest);

        void Detele(DeleteModelRequest deleteModelRequest);

        void Update(UpdateModelRequest updateModelRequest);
    }
}
