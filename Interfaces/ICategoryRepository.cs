using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Interfaces
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> AllCategorys { get;}
    }
}