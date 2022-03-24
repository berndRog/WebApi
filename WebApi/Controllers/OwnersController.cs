using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controllers; 
[Route("banking/owners")]
//[ApiController]
public class OwnersController : ControllerBase {
   
   private readonly IRepository _repository;

   public OwnersController(IRepository repository) {
      _repository = repository;
   }

   [HttpGet()]
   public ActionResult<IEnumerable<Owner>> Get() {
      try {
         var owners = _repository.Select();
         return Ok(owners);
      }
      catch (Exception e) {
         return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
   }

   [HttpGet("{id}")]
   public ActionResult<Owner> GetById(Guid id) {
      try {
         var owner = _repository.FindById(id);
         if(owner != null) return Ok(owner);
         else              return NotFound();
      }
      catch (Exception e) {
         return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }    
   }

   [HttpPost()]
   public ActionResult<Owner> Post([FromBody] Owner owner) {
      
      if(!ModelState.IsValid) return BadRequest(ModelState);
      try {
         if(owner.Id == Guid.Empty) owner.Id = Guid.NewGuid(); 
         _repository.Add(owner);
         return Created(
            uri: new Uri($"{Request.Path}/{owner.Id}", UriKind.Relative),
            value: owner         
         );
      }
      catch (Exception e) {
         return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
   }
}