using System;
using System.Collections.Generic;
using johnsBurgers.Models;
using johnsBurgers.Repositories;

namespace johnsBurgers.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _repo;

    public BurgersService(BurgersRepository tr)
    {
      _repo = tr;
    }

    public IEnumerable<Burger> Get()
    {
      return _repo.Get();
    }
    public Burger Create(Burger newBurger)
    {
      int id = _repo.Create(newBurger);
      newBurger.Id = id;
      return newBurger;
    }
    public Burger Get(int burgerId)
    {
      Burger exists = _repo.GetById(burgerId);
      if (exists == null) { throw new Exception("Invalid burger mi amigo"); }
      return exists;
    }

    public Burger Delete(int id)
    {
      Burger exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Burger Edit(Burger editBurger)
    {
      Burger original = Get(editBurger.Id);
      original.Name = editBurger.Name == null ? original.Name : editBurger.Name;
      original.Price = editBurger.Price > 0 ? editBurger.Price : original.Price;
      original.Description = editBurger.Description == null ? original.Description : editBurger.Description;
      return _repo.Edit(original);
    }


  }
}