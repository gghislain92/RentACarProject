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

namespace DataAccess.Concretes
{
    public class ModelDal : EfEntityRepositoryBase<Model, RentACarContext>, IModelDal
    {
        public List<Model> GetAllWithBrand()
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Models.Include(p => p.Brand).ToList();
            }
        }

        public List<Model> GetAllWithBrand(string productName)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Models.Include(p => p.Brand)
                    .Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList();
            }
        }
    }
}
