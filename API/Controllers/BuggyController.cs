using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
            => _context.Products.Find(42) != null ? Ok() : NotFound();
        

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {            
            string thingToReturn = _context.Products.Find(42).ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return BadRequest();
        }

    }
}