using DAS.Services.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Services.Interface
{
    public interface IQuestionReasonRepository
    {
        QuestionReasonModal Get(string whereCondition, string orderBy);
        List<QuestionReasonModal> GetAll(string whereCondition, string orderBy);
        ResultDTO Create(QuestionReasonModal QuesReasModal);
        ResultDTO Update(QuestionReasonModal QuesReasModal);
    }
}
