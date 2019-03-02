using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_CITIES.Models.Repository
{
    /// <summary>
    /// Generic repository interface (CRUD operation)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        List<T> GetAllList();
        List<T> GetListFromID(string id);
        void Update(T obj);
        void DeleteByID(T obj);
    }
}
