using Business.Dtos.Request;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Update.Internal;
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
        Model GetById(int id);

        void Add(CreateModelRequest createModelRequest);
        void update(UpdateModelRequest updateModelRequest);
        void delete(DeleteModelRequest deleteModelRequest);
    }
}
