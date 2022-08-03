using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = Mockperson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person Mockperson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Address = "some addrress",
                FirstName = "first name" + i,
                LastName = "last name " + i ,
                Gender = "Masculino"
            };
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Address = "rua cidade do porto",
                FirstName = "Otavio",
                LastName = "Oliveira",
                Gender = "Masculino"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
