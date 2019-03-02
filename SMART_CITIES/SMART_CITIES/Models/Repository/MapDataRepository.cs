using SMART_CITIES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMART_CITIES.Models.Repository
{
    public class MapDataRepository : CommonRepository,  IRepository<Traffic>
    {
        public MapDataRepository() : base()
        {

        }
        /// <summary>
        /// delete data by id
        /// </summary>
        /// <param name="obj"></param>
        public void DeleteByID(Traffic obj)
        {
            dbContext.Traffic.Remove(obj);
            dbContext.SaveChanges();        
        }

        /// <summary>
        /// get all data list
        /// </summary>
        /// <returns></returns>
        public List<Traffic> GetAllList()
        {
            return dbContext.Traffic.ToList();
        }

        /// <summary>
        /// get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Traffic> GetListFromID(string number)
        {
            return dbContext.Traffic.Where(p => p.aNumber == number).ToList();
        }

        /// <summary>
        /// update data by id
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Traffic obj)
        {
            dbContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}