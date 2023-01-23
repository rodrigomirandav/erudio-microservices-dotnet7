using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Services.Interfaces;

public interface IPersonService
{
    Person Create(Person person);
    Person Update(Person person);   
    List<Person> GetAll();
    Person FindById(long id);
    void Delete(long id);    
}
