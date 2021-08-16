using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAPI.Models;
using ContactAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return ContactService.GetAll();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return ContactService.Get(id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] Contact c)
        {
            ContactService.Create(c);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact c)
        {
            ContactService.Update(id, c);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ContactService.Delete(id);
        }

        [HttpGet("call-list")]
        public Object GetCallList()
        {
            return ContactService.GetCallList();
        }
    }
}
