using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.API.Models;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "240SecondsCacheProfile")]
    public  class BkBaoKaJlController : ControllerBase
    {
        private readonly IBkBaoKaJlRepository _bkBaoKaJlRepository;
        public BkBaoKaJlController(IBkBaoKaJlRepository bkBaoKaJlRepository)
        {
            _bkBaoKaJlRepository = bkBaoKaJlRepository;
        }

        /// <summary>
        /// 根据id进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetbkBaoKaJlById(Guid id)
        {
            var bkBaoKaJl= await _bkBaoKaJlRepository.GetBkBaoKaJlByIdAaync(id);

            //返回204
            return Ok(bkBaoKaJl);
        }
    }
}
