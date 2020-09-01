using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using johnsBurgers.Models;
using johnsBurgers.Services;

namespace johnsBurgers.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ToppingsController : ControllerBase
  {
    private readonly ToppingsService _service;
    public ToppingsController(ToppingsService service)
    {
      _service = service;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Topping>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //GETBYID
    [HttpGet("{Id}")]
    public ActionResult<Topping> Get(int Id)
    {
      try
      {
        return Ok(_service.Get(Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Topping> Post([FromBody] Topping newTopping)
    {
      try
      {
        return Ok(_service.Create(newTopping));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Topping> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Topping> Edit([FromBody] Topping newTopping, int id)
    {
      try
      {
        newTopping.Id = id;
        return Ok(_service.Edit(newTopping));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}