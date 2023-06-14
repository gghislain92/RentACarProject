using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Request
{
    public class UpdateModelRequest
    {
        public string Name { get; set; }
        public double dailyPrice { get; set; }

        public int BrandId { get; set; }
    }
}
