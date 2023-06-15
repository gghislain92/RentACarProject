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
    public class BrandBusinessRules
    {
        IBrandDal _brandDal;

        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        //product names can not be duplicated
        public void BrandNameCanNotBeDuplicated(string brandName)
        {
            Brand? brand  = _brandDal.Get(b =>b.Name == brandName);

            if (brand != null)
            {
                throw new Exception("Brand name already exists");
            }
        }

        public void BrandIdCanNotBeFound(string brandName)
        {
            Brand? brand = _brandDal.Get(b =>b.Name == brandName);

            if (brand != null)
            {
                throw new Exception("Brand name not found.");
            }
        }
    }
}