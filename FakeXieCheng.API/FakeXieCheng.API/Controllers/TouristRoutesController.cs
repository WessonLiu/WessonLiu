using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Profiles;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FakeXieCheng.API.Controllers
{
    //路由声明
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {

        private ITouristRouteRepository _touristRouteRepository;
        //如果是私有变量要用 readonly
        private readonly IMapper _mapper;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository,IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }
        //api/TouristRoutes/GetTouristRoutes
        [HttpGet("{touristRouteId}")]
        public async Task<IActionResult> GetTouristRoutes(string touristRouteId)
        {
            
            //test = test * (test ?? 1);
            var routes = (await _touristRouteRepository.GetTouristRoutesByIdAaync(touristRouteId));//.MapTo();
            if (routes==null )
            {
                return NotFound($"没有找到旅游路线{touristRouteId}");
            }

            var routesDto = _mapper.Map<TouristRouteDto>(routes);
            return Ok(routesDto);
        }
        [HttpGet("{touristRouteId}")]
        public async Task<IActionResult> GetTouristRoute(string touristRouteId)
        {
            //封装资源库。
            //test = test * (test ?? 1);
            var routes = (await _touristRouteRepository.GetTouristRoutesByIdAaync(touristRouteId));//.MapTo();
            if (routes == null)
            {
                return NotFound($"没有找到旅游路线{touristRouteId}");
            }

            var routesDto = _mapper.Map<TouristRouteDto>(routes);
            return Ok(routesDto);
        }

        /// <summary>
        /// put 和 patch
        /// put全部更新   和 Patch 进行局部更新
        /// 通过patch减少带宽
        /// put 请求是不安全的
        /// JsonPatch
        /// patch可以对嵌套资源进行判断
        /// jsonPatch 有6个操作
        /// add 添加某个字段， remove 删除某个字段 replace 替换某个字段的数据
        /// move转移   copy复制    test 测试
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateTouResult([FromRoute]string id ,[FromBody]TouristRouteUpdateDto touristRouteUpdateDto)
        {
            //先判断路线是否存在
           // if (!_touristRouteRepository.GetTouristRoutesByIdAaync(id))
//            {
//                return NotFound($"找不到旅游路线{id}");
//            }

            var touristRoute = _touristRouteRepository.GetTouristRoutesByIdAaync(id);
            //1:映射dto
            //2:更新Dto数据
            //3：映射Model
            _mapper.Map(touristRouteUpdateDto, touristRoute);
            
            _touristRouteRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// 删除数据 根据id进行删除
        /// 批量删除，现根据 传值进行查询， 然后进行删除。
        /// 通过removeRange进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteTouristRoutes([FromRoute] string id)
        {
            if (!_touristRouteRepository.GetTouristRoutesExists(id))
            {
                return NotFound($"找不到旅游路线{id}");
            }

            var touristRoutes = _touristRouteRepository.GetTouristRoute(id);
            _touristRouteRepository.DeleteTouristRoues(touristRoutes);
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdateToutistRoutes([FromRoute] string id,
            [FromBody]JsonPatchDocument<TouristRouteUpdateDto> patchDocument)
        {

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetTouristRoutesList(string touristRouteId)
        {
            if (string.IsNullOrWhiteSpace(touristRouteId))
            {
                return NotFound($"没有找到旅游路线{touristRouteId}");
            }
            var toures = await _touristRouteRepository.GetTouristRoutesByIdAaync(touristRouteId);
            return Ok(toures);
        }
    }
}
