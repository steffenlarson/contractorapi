using System;
using System.Data;
using Dapper;
using contractorapi.Models;

namespace contractorapi.Repositories
{
  public class ContractorJobsRepository
  {


    private readonly IDbConnection _db;

    public ContractorJobsRepository(IDbConnection db)
    {
      _db = db;
    }



    public int Create(ContractorJobs newCj)
    {
      string sql = @"
        INSERT INTO contractorjobs
        (contractorId, jobId)
        VALUES
        (@ContractorId, @JobId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newCj);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractorjobs WHERE id = @id;";
      _db.Execute(sql, new { id });
    }



  }
}