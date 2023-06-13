using Data_Access.Repository;
using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Abstracts
{
    public interface IBrandDal : IEntityRepository<Brand>
    {  
    }
}
