using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Models;

namespace Contoso.Data
{
    public class PersonRepository
    {
        ContosoDbContext db;
        public PersonRepository()
        {
            db = new ContosoDbContext();
        }

        public Person GetPersonById(int id)
        {
            return db.People.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return db.People.ToList();
        }

        public void Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }

        public void Update(Person person)
        {
            var targetPerson = db.People.Find(person.Id);
            targetPerson.FirstName = person.FirstName;
            targetPerson.LastName = person.LastName;
            targetPerson.DateOfBirth = person.DateOfBirth;
            db.SaveChanges();

        }
    }
}
