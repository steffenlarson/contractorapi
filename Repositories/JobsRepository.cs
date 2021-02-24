using System.Collections.Generic;
using System.Data;
using contractorapi.Models;
using Dapper;

namespace contractorapi.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }



    internal IEnumerable<Job> Get()
    {
      string sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql);
    }

    internal Job getById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal int Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (name, description)
      VALUES
      (@Name, @Description);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newJob);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id;";
      _db.Execute(sql, new { id });
    }


    internal Job Edit(Job original)
    {
      string sql = @"
          UPDATE jobs
          SET
              name = @Name,
              description = @Description
          WHERE id = @Id;
          SELECT * FROM jobs WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Job>(sql, original);
    }


    internal IEnumerable<Job> GetJobsByContractorId(int contractorId)
    {
      string sql = @"
      SELECT j.*,
      cj.id as ContractorJobId 
      FROM contractorjobs cj
      JOIN jobs j ON j.id = cj.jobId
      WHERE contractorId = @contractorId";

      return _db.Query<ContractorJobViewModel>(sql, new { contractorId });
    }


  }
}