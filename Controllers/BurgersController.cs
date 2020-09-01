using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using johnsBurgers.Models;
using johnsBurgers.Services;

namespace johnsBurgers.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _service;

    private readonly ToppingsService _toppingService;
    public BurgersController(BurgersService service, ToppingsService toppingsService)
    {
      _service = service;
      _toppingService = toppingsService;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
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
    [HttpGet("{burgerId}")]
    public ActionResult<Burger> Get(int burgerId)
    {
      try
      {
        return Ok(_service.Get(burgerId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{burgerId}/toppings")]
    public ActionResult<Topping> GetToppingsByComboId(int burgerId)
    {
      try
      {
        return Ok(_toppingService.GetToppingsByBurgerId(burgerId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Burger> Post([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_service.Create(newBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
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
    public ActionResult<Burger> Edit([FromBody] Burger newBurger, int id)
    {
      try
      {
        newBurger.Id = id;
        return Ok(_service.Edit(newBurger));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}