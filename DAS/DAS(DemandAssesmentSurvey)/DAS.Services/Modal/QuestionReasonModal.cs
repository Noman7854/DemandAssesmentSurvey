using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAS.Services.Modal
{
    public class QuestionReasonModal
    {
        public int QuestionReasonId { get; set; }
        public int QuestionId { get; set; }
        public string Reason { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDt { get; set; }
    }
}