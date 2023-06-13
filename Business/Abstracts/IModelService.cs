using Business.Dtos.Request;
using Business.Dtos.Response;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IModelService
    {
        List<GetModelResponse> GetAll();
        List<GetModelResponse> GetAll(string modelName);

        void Add(CreateModelRequest createModelRequest);

    }
}
