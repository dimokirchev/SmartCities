using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMART_CITIES.Models.ViewModel
{
    /// <summary>
    /// View model
    /// </summary>
    public class SmartCitiesVM
    {
        public Nullable<decimal> cellLong { get; set; }
        public Nullable<decimal> cellLat { get; set; }

        public int count { get; set; }

        public List<DateTime?> datesFilter { get; set; }

        public List<int?> ageFilter { get; set; }
    }

}