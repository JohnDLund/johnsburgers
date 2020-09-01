using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using johnsBurgers.Models;

namespace johnsBurgers.Repositories
{
  public class ToppingsRepository
  {
    private readonly IDbConnection _db;
    public ToppingsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Topping> Get()
    {
      string sql = "SELECT * FROM toppings";
      return _db.Query<Topping>(sql);
    }

    internal Topping GetById(int Id)
    {
      string sql = "SELECT * FROM toppings WHERE id = @Id";
      return _db.QueryFirstOrDefault<Topping>(sql, new { Id });
    }

    internal int Create(Topping newTopping)
    {
      string sql = @"
        INSERT INTO toppings
        (kcal, name)
        VALUES
        (@Kcal, @Name);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newTopping);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM toppings WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Topping Edit(Topping original)
    {
      string sql = @"
        UPDATE toppings
        SET
            name = @Name,
            kcal = @Kcal
        WHERE id = @Id;
        SELECT * FROM toppings WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Topping>(sql, original);
    }
  }
}