using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Data;
using Contoso.Models;

namespace Contoso.Services
{
    public class PersonService
    {
        PersonRepository personRepository;
        public PersonService()
        {
            personRepository = new PersonRepository();
        }

        public Person GetPersonById(int id)
        {
            return personRepository.GetPersonById(id);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return personRepository.GetAllPeople();
        }

        public void Create(Person person)
        {
            personRepository.Create(person);
        }

        public void Update(Person person)
        {
            personRepository.Update(person);
        }
    }
}
