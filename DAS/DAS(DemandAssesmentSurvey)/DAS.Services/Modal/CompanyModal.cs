using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace DAS.Services.Modal
{
    public class CompanyModal
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDt { get; set; }







    }
}