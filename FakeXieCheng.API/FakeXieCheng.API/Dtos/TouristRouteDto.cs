using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Dtos
{
    public class TouristRouteDto
    {
        public string id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal OriginalPrice { get; set; }

        public int DiscountPresent { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime DepartureTime { get; set; }
    }
}
