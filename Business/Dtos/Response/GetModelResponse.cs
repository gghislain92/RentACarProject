using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Response
{
    public class GetModelResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public double dailyPrice { get; set; }
        
        public int BrandId { get; set; }
        
        public string BrandName { get; set; }
    }
}
