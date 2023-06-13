using Business.Abstracts;
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
    public class BrandManager : IBrandService
    {

        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll(){

            return _brandDal.GetList().ToList();
        }

        public List<Brand> GetAll(string brandName)
        {
            return _brandDal.GetList(b=>b.Name.Contains(brandName).ToList();
        }
    }
}
