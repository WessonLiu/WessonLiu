using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.API.Services
{
    public interface IBkBaoKaJlRepository
    {
        Task<BkBaoKaJl> GetBkBaoKaJlByIdAaync(Guid guid); //根据id查询旅游路线

        void AddBkBaoKaJl(BkBaoKaJl bkBaoKaJl);//添加数据
        void UpdateBkBaoKaJl(BkBaoKaJl bkBaoKaJl);//修改数据
    }
}
