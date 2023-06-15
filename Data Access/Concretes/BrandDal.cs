using Data_Access.Abstracts;
using Data_Access.Contexts;
using Data_Access.Repository;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concretes
{
    public class BrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public List<Brand> GetAllWithModel()
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Brands.Include(p => p.Models).ToList();
            }
        }

        public List<Brand> GetAllWithModel(string modelName)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Brands.Include(b => b.Models)
                    .Where(b => b.Name.ToLower().Contains(modelName.ToLower())).ToList();
            }
        }


    }
}
