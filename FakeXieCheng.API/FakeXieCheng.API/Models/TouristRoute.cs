using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Models
{
    public class TouristRoute
    {
        public  string ID  { get; set; }
        public  string TITLE  { get; set; }

        public string DESCRIPTION { get; set; }

        public decimal ORIGINALPRICE { get; set; }

        public int DISCOUNTPRESENT { get; set; }

        public DateTime CREATETIME { get; set; }

        public DateTime? UPDATETIME { get; set; }

        public DateTime DEPARTURETIME { get; set; }

//        public TravelDays? TravelDays { get; set; }
//
//        public TripType? TripType { get; set; }
    }
}
