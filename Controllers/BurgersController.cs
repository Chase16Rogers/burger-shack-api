using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using burger_shack_api.Models;
using burger_shack_api.Services;
using System;
namespace burger_shack_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase
    {
        private readonly BurgersService _BS;
        public BurgersController(BurgersService bs)
        {
            _BS = bs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Burger>> Get()
        {
            try
            {
               return Ok(_BS.GetAll());
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Burger> Get(int id)
        {
            try
            {
                return Ok(_BS.GetOne(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Burger> Create([FromBody] Burger newBurger)
        {
            try
            {
                return Ok(_BS.Create(newBurger));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Burger> Edit(int id, [FromBody] Burger editBurger)
        {
            try
            {
                return Ok(_BS.Edit(id, editBurger));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Burger> Delete(int id)
        {
             try
            {
                return Ok(_BS.Delete(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }

}