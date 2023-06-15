using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Responses;
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
    public class BrandManager : IBrandService
    {

        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
            rules = new BrandBusinessRules(_brandDal);
        }

        BrandBusinessRules rules;

        public void Add(CreateBrandRequest createBrandRequest)
        {
            rules.BrandNameCanNotBeDuplicated(createBrandRequest.Name);

            Brand brand = new Brand
            {
                Name = createBrandRequest.Name,
            };
            _brandDal.Add(brand);
        }
        public Brand GetById(int brandId)
        {
            return _brandDal.Get(m => m.Id == brandId);
        }

        public List<GetBrandResponse> GetAll()
        {

            //business rules
            List<Brand> brands = _brandDal.GetAllWithModel().ToList();

            List<GetBrandResponse> getBrandResponses = new List<GetBrandResponse>();

            foreach (Brand brand in brands)
            {
                GetBrandResponse getBrandResponse = new GetBrandResponse();
                getBrandResponse.Name = brand.Name;
                getBrandResponse.Id = brand.Id;

                getBrandResponses.Add(getBrandResponse);
            }

            return getBrandResponses;

        }

        public List<GetBrandResponse> GetAll(string brandName)
        {
            List<Brand> brands =
                _brandDal.GetAllWithModel(brandName).ToList();

            List<GetBrandResponse> getBrandResponses = new List<GetBrandResponse>();

            foreach (Brand brand in brands)
            {
                GetBrandResponse getBrandResponse = new GetBrandResponse();
                getBrandResponse.Name = brand.Name;
                getBrandResponse.Id = brand.Id;


                getBrandResponses.Add(getBrandResponse);
            }

            return getBrandResponses;
        }


        public void update(UpdateBrandRequest updateBrandRequest)
        {
            rules.BrandNameCanNotBeDuplicated(updateBrandRequest.Name);

            Brand brand = _brandDal.Get(m => m.Id == updateBrandRequest.Id);
            if (brand != null)
            {
                brand.Name = updateBrandRequest.Name;
                _brandDal.Update(brand);
            }
        }
        public void delete(DeleteBrandRequest deleteBrandRequest)
        {
            Brand brand = _brandDal.Get(m => m.Id == deleteBrandRequest.Id);
            _brandDal.Delete(brand);
        }
    }
}
