using System;
using System.Collections.Generic;
using johnsBurgers.Models;
using johnsBurgers.Repositories;

namespace johnsBurgers.Services
{
  public class ToppingsService
  {
    private readonly ToppingsRepository _repo;
    public ToppingsService(ToppingsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Topping> Get()
    {
      return _repo.Get();
    }
    public Topping Get(int Id)
    {
      Topping exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid topping mi amigo"); }
      return exists;
    }

    public Topping Create(Topping newTopping)
    {
      int id = _repo.Create(newTopping);
      newTopping.Id = id;
      return newTopping;
    }

    public Topping Delete(int id)
    {
      Topping exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Topping Edit(Topping editTopping)
    {
      Topping original = Get(editTopping.Id);
      original.Name = editTopping.Name == null ? original.Name : editTopping.Name;
      original.KCal = editTopping.KCal > 0 ? editTopping.KCal : original.KCal;
      return _repo.Edit(original);
    }

    internal object GetToppingsByBurgerId(int burgerId)
    {
      throw new NotImplementedException();
    }
  }
}