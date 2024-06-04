using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Services.Modal
{
    public class ProductModal
    {
            public int ProductId         { get; set; }
            public int CompanyId         { get; set; }
            public string ProductName    { get; set; }
            public string ProductType    { get; set; }
            public bool IsDelete         { get; set; }
            public string CreatedBy      { get; set; }
            public DateTime CreatedDt    { get; set; }
            public string ModifiedBy     { get; set; }
            public DateTime ModifiedDt   { get; set; }

    }
}