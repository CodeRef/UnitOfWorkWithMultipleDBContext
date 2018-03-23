using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW_MultipleDBContext.Entity;

namespace UoW_MultipleDBContext.Service.IService
{
    public interface ICategoryService
    {
        List<Category> CallRightOne();
    }
}
