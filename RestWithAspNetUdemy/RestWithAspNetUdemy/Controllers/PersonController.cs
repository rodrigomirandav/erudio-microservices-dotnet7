using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services.Interfaces;

namespace RestWithAspNetUdemy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;
    public PersonController(ILogger<PersonController> logger,
                            IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_personService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);

        if (person == null)
            return NotFound("");

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);

        return NoContent();
    }
}
