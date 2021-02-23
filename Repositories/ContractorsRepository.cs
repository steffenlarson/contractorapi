using System.Collections.Generic;
using System.Data;
using contractorapi.Models;
using Dapper;

namespace contractorapi.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }



    internal IEnumerable<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql);
    }

    internal Contractor getById(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal int Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name, description)
      VALUES
      (@Name, @Description);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id;";
      _db.Execute(sql, new { id });
    }


    internal Contractor Edit(Contractor original)
    {
      string sql = @"
          UPDATE contractors
          SET
              name = @Name,
              description = @Description
          WHERE id = @Id;
          SELECT * FROM contractors WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, original);
    }


  }
}