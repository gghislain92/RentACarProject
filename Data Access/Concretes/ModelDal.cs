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
    public class ModelDal : EfEntityRepositoryBase<Model, RentACarContext>, IModelDal
    {
        public List<Model> GetAllWithBrand()
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Models.Include(m => m.Brand).ToList();
            }
        }

        public List<Model> GetAllWithBrand(string modelName)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Models.Include(m => m.Brand)
                    .Where(m => m.Name.ToLower().Contains(modelName.ToLower())).ToList();
            }
        }
    }
}
