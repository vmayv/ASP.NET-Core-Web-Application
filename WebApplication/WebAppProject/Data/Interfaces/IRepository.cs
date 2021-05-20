using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProject.Data.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T Find(string term);
        List<T> GetListOfItems(int skip, int take);
        int CreateItem();
        int EditItem(T item);
        int DeleteItem(int id);

    }
}
