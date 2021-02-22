using System.Collections.Generic;
using System.Data;
using Dapper;
using burger_shack_api.Models;

namespace burger_shack_api.Repositories
{
    public class BurgerRepository
    {
        public readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
        {
            _db = db;
        }

    public IEnumerable<Burger> GetAll()
        {
            string sql = "SELECT * FROM burgers;";
            return _db.Query<Burger>(sql);
        }

    public Burger GetOne(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @id";
        return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    internal Burger Create(Burger newBurger)
    {
        string sql = "INSERT INTO burgers (name, description, price) VALUES (@name, @description, @price);";
        int id = _db.ExecuteScalar<int>(sql, newBurger);
        return newBurger;
    }

    internal Burger Edit(Burger editBurger)
    {
        string sql = @"UPDATE burgers SET description = @description, price = @price, name = @name WHERE id = @id;
                        SELECT * FROM burgers WHERE id = @id;";
        return _db.QueryFirstOrDefault<Burger>(sql, editBurger);
    }

    internal string Delete(Burger deleteMe)
    {
        string sql = "DELETE FROM burgers WHERE id = @id;";
        _db.Execute(sql,deleteMe);
        return "All gone boss!";
    }

    }
}