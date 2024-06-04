using DAS.Services.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Services.Interface
{
    public interface ICompanyRepository
    {
        CompanyModal Get(string whereCondition, string orderBy);
        List<CompanyModal> GetAll(string whereCondition, string orderBy);
        ResultDTO Create(CompanyModal companyModal);
        ResultDTO Update(CompanyModal companyModal);
    }
}
