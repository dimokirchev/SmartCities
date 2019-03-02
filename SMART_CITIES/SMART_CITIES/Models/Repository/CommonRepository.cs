using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMART_CITIES.Models.Repository
{
    /// <summary>
    /// Repository about data 
    /// </summary>
    public class CommonRepository
    {
        protected SMART_CITIESEntities dbContext;
        public CommonRepository()
        {
            this.dbContext = new SMART_CITIESEntities();
        }
    }
}