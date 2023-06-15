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
    public interface IBrandService
    {

        List<GetBrandResponse> GetAll();
        List<GetBrandResponse> GetAll(string modelName);
        Brand GetById(int id);

        void Add(CreateBrandRequest createBrandRequest);
        void update(UpdateBrandRequest updateBrandRequest);
        void delete(DeleteBrandRequest deleteBrandRequest);

    }
}
