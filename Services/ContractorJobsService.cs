using System;
using contractorapi.Models;
using contractorapi.Repositories;


namespace contractorapi.Services
{
  public class ContractorJobsService
  {

    private readonly ContractorJobsRepository _repo;

    public ContractorJobsService(ContractorJobsRepository repo)
    {
      _repo = repo;
    }

    public ContractorJobs Create(ContractorJobs newCj)
    {
      int id = _repo.Create(newCj);
      newCj.Id = id;
      return newCj;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }


  }
}