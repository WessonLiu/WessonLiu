using FakeXieCheng.API.Database;
using FakeXieCheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FakeXieCheng.API.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddTouristRoues(TouristRoute touristRoute)
        {

            throw new NotImplementedException();
        }

        public void DeleteTouristRoues(TouristRoute touristRoute)
        {
            _context.TOURISTROUTE.Remove(touristRoute);
        }

        public TouristRoute GetTouristRoute(string id)
        {
            return _context.TOURISTROUTE.Include(t => t.ID == id).FirstOrDefault();
        }

        public  Task<List<TouristRoute>> GetTouristRoutes(string kewory)
        {
            //linq 表达式 创建sql语句
            //IQueryable 延迟执行
            //聚合操作 进行数据库操作  .list() .count()   ==
            var tourist =  _context.TOURISTROUTE.Where(t => t.ID == t.ID);
            if (!string.IsNullOrWhiteSpace(kewory))
            {
                kewory = kewory.Trim();
                tourist.Where(t => t.TITLE.Contains(kewory));
            }
            return tourist.ToListAsync();
        }

        /// <summary>
        ///  根据ID查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TouristRoute> GetTouristRoutesByIdAaync(string id)
        {
            return await _context.TOURISTROUTE.FirstOrDefaultAsync(t=>t.ID =="1");
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void UpdateTouristRoues(TouristRoute touristRoute)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TouristRoute>> ITouristRouteRepository.GetTouristRoutes(string kewory)
        {
            throw new NotImplementedException();
        }

        public bool GetTouristRoutesExists(string id)
        {
            //any关键词，返回的是bool类型， 当有数据的时候，返回true
            return _context.TOURISTROUTE.Any(t => t.ID == id);
            
        }
    }
}
