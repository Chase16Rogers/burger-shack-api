using System.Collections.Generic;
using burger_shack_api.Services;
using Microsoft.AspNetCore.Mvc;
using burger_shack_api.Models;
using System;
namespace burger_shack_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SidesController : ControllerBase
    {
        private readonly SidesService _SS;

    public SidesController(SidesService sS)
    {
      _SS = sS;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Side>> GetAll()
    {
        try
        {
            return _SS.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Side> GetOne(int id)
    {
        try
        {
            return _SS.GetOne(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    public ActionResult<Side> Create([FromBody] Side newSide)
    {
        try
        {
            return _SS.Create(newSide);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
[HttpPut("{id}")]
    public ActionResult<Side> Edit(int id, [FromBody] Side editSide )
    {
        try
        {
            return _SS.Edit(id, editSide);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




  }
}