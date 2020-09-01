using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using johnsBurgers.Models;

namespace johnsBurgers.Repositories
{
  public class BurgersRepository
  {
    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Burger> Get()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    internal Burger GetById(int burgerId)
    {
      string sql = "SELECT * FROM burgers WHERE id = @burgerId";
      return _db.QueryFirstOrDefault<Burger>(sql, new { burgerId });
    }

    internal int Create(Burger newBurger)
    {
      string sql = @"
        INSERT INTO burgers
        (description, name, price)
        VALUES
        (@Description, @Name, @Price);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBurger);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Burger Edit(Burger original)
    {
      string sql = @"
        UPDATE burgers
        SET
            name = @Name,
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM burgers WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Burger>(sql, original);
    }
  }
}