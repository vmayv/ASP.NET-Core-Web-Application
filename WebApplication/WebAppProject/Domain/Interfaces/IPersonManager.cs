using System.Collections.Generic;
using WebAppProject.Models;
using WebAppProject.Models.DTO;

namespace WebAppProject.Domain.Interfaces
{
    public interface IPersonManager
    {
        Person GetById(int id);
        List<Person> Find(string term);
        List<Person> GetListOfItems(int skip, int take);
        int CreateItem(CreatePersonRequest personDto);
        int EditItem(EditPersonRequest personDto);
        int DeleteItem(int id);
    }
}