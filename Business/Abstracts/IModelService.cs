using Business.Dtos.Request;
using Business.Dtos.Responses;
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

        List<GetModelResponse> GetAll();

        List<GetModelResponse> GetAll(string modelName);
        Model GetById(int id);

        void Add(CreateModelRequest createModelRequest);
        void Update(UpdateModelRequest updateModelRequest);
        void Detele(DeleteModelRequest deleteModelRequest);
    }
}
