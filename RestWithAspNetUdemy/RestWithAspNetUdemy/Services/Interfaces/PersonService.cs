using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Services.Interfaces
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Rodrigo",
                LastName = "Miranda",
                Address = "São Paulo",
                Gender = "Male"
            };
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        private Person MockPerson(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = "Male"
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
