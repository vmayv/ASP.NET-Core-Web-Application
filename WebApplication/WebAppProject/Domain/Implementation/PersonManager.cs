using System;
using System.Collections.Generic;
using WebAppProject.Data.Interfaces;
using WebAppProject.Domain.Interfaces;
using WebAppProject.Models;
using WebAppProject.Models.DTO;

namespace WebAppProject.Domain.Implementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public List<Person> Find(string term)
        {
            return _personRepository.Find(term);
        }

        public List<Person> GetListOfItems(int skip, int take)
        {
            return _personRepository.GetListOfItems(skip, take);
        }

        public int CreateItem(CreatePersonRequest personDto)
        {
            var person = new Person()
            {
                Age = personDto.Age, Company = personDto.Company, Email = personDto.Email,
                FirstName = personDto.FirstName, LastName = personDto.LastName, Id = _personRepository.GetLastId()+1
            };
            return _personRepository.CreateItem(person);
        }

        public int EditItem(EditPersonRequest personDto)
        {
            var person = new Person()
            {
                Age = personDto.Age, Company = personDto.Company, Email = personDto.Email,
                FirstName = personDto.FirstName, Id = personDto.Id, LastName = personDto.LastName
            };
            return _personRepository.EditItem(person);
        }

        public int DeleteItem(int id)
        {
            return _personRepository.DeleteItem(id);
        }
    }
}