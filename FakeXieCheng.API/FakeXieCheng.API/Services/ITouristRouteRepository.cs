using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.API.Models;

namespace FakeXieCheng.API.Services
{
    public interface ITouristRouteRepository
    {
        Task<IEnumerable<TouristRoute>> GetTouristRoutes(string kewory);

        Task<TouristRoute> GetTouristRoutesByIdAaync(string id); //根据id查询旅游路线

        TouristRoute GetTouristRoute(string id);

        bool GetTouristRoutesExists(string id); //根据id查询旅游路线
        void AddTouristRoues(TouristRoute touristRoute);//添加数据

        void UpdateTouristRoues(TouristRoute touristRoute);//修改数据

        void DeleteTouristRoues(TouristRoute touristRoute); //删除数据库

        void Save(); //提交到数据库
    }
}
