using SMART_CITIES.Models;
using SMART_CITIES.Models.Repository;
using SMART_CITIES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMART_CITIES.Controllers
{
    public class MapInfoesController : ApiController
    {
        private MapDataRepository repo = new MapDataRepository();



        [Route("api/MapInfoes/get")]
        public List<SmartCitiesVM> GetMapInfoes(string age, string gender, string date)
        {
            // all data to view
            List<SmartCitiesVM> VMList = new List<SmartCitiesVM>();
            List<Traffic> GetData = new List<Traffic>();
            GetData = repo.GetAllList();
            if(!string.IsNullOrEmpty(gender))
            {
                if (gender == "M")
                {
                    GetData = GetData.Where(p => p.Customer.gender == "M").ToList();
                }
                else if (gender == "F")
                {
                    GetData = GetData.Where(p => p.Customer.gender == "F").ToList();
                }
                else if (gender == "?")
                {
                    GetData = GetData.Where(p => p.Customer.gender == "?").ToList();
                }
            }

            //// age filters
            if (!string.IsNullOrEmpty(age))
            {
                string[] sectionAge = age.Split(';');
                foreach (var ageItem in sectionAge)
                {
                    string[] AgeNumber = ageItem.Split('-');
                    int min = Convert.ToInt32(AgeNumber[0]);
                    int max = Convert.ToInt32(AgeNumber[1]);

                    GetData = GetData.Where(p => p.Customer.age > min && p.Customer.age < max).ToList();
                }
            }



            //datetime filter
            if(!string.IsNullOrEmpty(date))
            {
                DateTime filterDate = Convert.ToDateTime(date);
                GetData = GetData.Where(p => p.startDateTime.Value.Date == filterDate.Date).ToList();
            }
           


            // grouped data by GPS coordinates
            var data = GetData.GroupBy(x => new { x.cellLat, x.cellLong });

            // filters data
            List<int?> Ages = new List<int?>();
            List<DateTime?> Dates = new List<DateTime?>();

            // loop grouped data
            foreach (var item in data)
            {
                // age filter
                var Years = item.Select(p => p.Customer.age).Distinct().ToList();
                foreach (var ItemAge in Years)
                {
                    bool result = Ages.Any(i => i == ItemAge);
                    if (!result)
                    {
                        Ages.Add(ItemAge);
                    }
                }
                // date filter
                var DatesList = item.Select(p => p.startDateTime.Value.Date).Distinct().ToList();
                foreach (var ItemDate in DatesList)
                {
                    bool result = Dates.Any(i => i == ItemDate);
                    if (!result)
                    {
                        Dates.Add(ItemDate);
                    }
                }
                // fill data
                SmartCitiesVM VM = new SmartCitiesVM();
                if (item.Select(p => p.cellLat) == null)
                {
                    VM.cellLat = null;
                }
                else
                {
                    VM.cellLat = item.Select(p => p.cellLat).First();
                }
                if (item.Select(p => p.cellLat) == null)
                {
                    VM.cellLong = null;
                }
                else
                {
                    VM.cellLong = item.Select(p => p.cellLong).First();
                }

                VM.count = item.Count();
                VMList.Add(VM);
            }

            // fill filters like last record
            SmartCitiesVM VMFilter = new SmartCitiesVM();
            VMFilter.ageFilter = Ages.Distinct().ToList();
            VMFilter.datesFilter = Dates.Distinct().ToList();
            VMList.Add(VMFilter);

            return VMList;
        }
    }
}