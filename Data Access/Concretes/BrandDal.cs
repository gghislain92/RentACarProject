using Data_Access.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concretes
{
    public class BrandDal: IBrandDal {
        public List<Brand> GetAll(){
            List<Brand> brands = new List<Brand>();
            brands.Add(new Brand { Id = 1, Name = "Nissan" });
            brands.Add(new Brand { Id = 2, Name = "Toyota" });
            brands.Add(new Brand { Id = 3, Name = "Mercedes Benz" });
            brands.Add(new Brand { Id = 4, Name = "Audi" });
            brands.Add(new Brand { Id = 5, Name = "Ford" });

            return brands;
        }
    }
}
