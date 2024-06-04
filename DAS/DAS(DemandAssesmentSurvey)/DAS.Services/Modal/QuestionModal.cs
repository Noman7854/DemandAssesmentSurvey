using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web;

namespace DAS.Services.Model
{
    public class QuestionModal
    {
        public int QuestionId { get; set; }

        public int CompanyId { get; set; }

        public string Question { get; set; }

        public string QuestionYear { get; set; }

        public bool IsDelete { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDt { get; set; }
    }
}