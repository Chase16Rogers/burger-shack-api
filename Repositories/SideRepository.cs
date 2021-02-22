using System.Collections.Generic;
using System.Data;
using burger_shack_api.Models;
using Dapper;

namespace burger_shack_api.Repositories
{
    public class SideRepository
    {
        public readonly IDbConnection _db;

        public SideRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Side> GetAll()
        {
            string sql = "SELECT * FROM sides;";
            return _db.Query<Side>(sql);
        }
        internal Side GetOne(int id)
        {
            string sql = "SELECT * FROM sides WHERE id = @id;";
            return _db.QueryFirstOrDefault<Side>(sql, new { id });
        }
        internal Side Create(Side newSide)
        {
            string sql = "INSERT INTO sides (name, description, price) VALUES (@name, @description, @price); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newSide);
            newSide.id = id;
            return newSide;
        }
        internal Side Edit(Side editSide)
        {
            string sql = @"UPDATE sides SET name = @name, description = @description, price = @price;
            SELECT * FROM sides WHERE id = @id";
            
        }
    }
}