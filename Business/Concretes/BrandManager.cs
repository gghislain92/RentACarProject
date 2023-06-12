using Data_Access.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager{
        public List<Brand> GetAll(){
            BrandDal brandDal = new BrandDal();
        }
    }
}
