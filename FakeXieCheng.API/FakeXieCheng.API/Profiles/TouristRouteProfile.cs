using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Models;

namespace FakeXieCheng.API.Profiles
{
    /// <summary>
    /// 用于autoMapper进行映射model 到 dto
    /// </summary>
    public class TouristRouteProfile :Profile
    {
        
        public TouristRouteProfile()
        {
            CreateMap<TouristRoute, TouristRouteDto>();

            //对数据默认值进行投影，如果不需要转换值， 则直接使用
            //.ForMember(
//            dest => dest.Price,
//            opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPercent ?? 1)));
        }
    }
}
