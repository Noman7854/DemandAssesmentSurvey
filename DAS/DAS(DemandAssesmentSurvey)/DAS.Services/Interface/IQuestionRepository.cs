using DAS.Services.Modal;
using DAS.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Services.Interface
{
    public interface IQuestionRepository
    {
        QuestionModal Get(string whereCondition, string orderBy);
        List<QuestionModal> GetAll(string whereCondition, string orderBy);

        ResultDTO Create(QuestionModal questionModel);

        ResultDTO Update(QuestionModal questionModel);
    }
}
