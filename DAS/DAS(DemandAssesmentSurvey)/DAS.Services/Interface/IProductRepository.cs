using DAS.Services.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Services.Interface
{
    public interface IProductRepository
    {
        ProductModal Get(string whereCondition, string orderBy);
        List<ProductModal> GetAll(string whereCondition, string orderBy);
        ResultDTO Create(ProductModal productModal);
        ResultDTO Update(ProductModal productModal);
    }
}
