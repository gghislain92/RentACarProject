using Data_Access.Abstracts;
using Data_Access.Contexts;
using Data_Access.Repository;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concretes
{
    public class ModelDal : EfEntityRepositoryBase<Model, RentACarContext>, IModelDal{

    }
}
