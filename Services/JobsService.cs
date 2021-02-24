using System;
using System.Collections.Generic;
using contractorapi.Models;
using contractorapi.Repositories;


namespace contractorapi.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    private readonly ContractorsRepository _crepo;

    public JobsService(JobsRepository repo, ContractorsRepository crepo)
    {
      _repo = repo;
      _crepo = crepo;
    }



    internal IEnumerable<Job> Get()
    {
      return _repo.Get();
    }

    internal Job getByID(int id)
    {
      Job exists = _repo.getById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Job Create(Job newJob)
    {
      int id = _repo.Create(newJob);
      newJob.Id = id;
      return newJob;
    }


    internal string Delete(int id)
    {
      getByID(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }


    internal Job Edit(Job editJob)
    {
      Job original = getByID(editJob.Id);

      original.Name = editJob.Name != null ? editJob.Name : original.Name;
      original.Description = editJob.Description != null ? editJob.Description : original.Description;

      return _repo.Edit(original);
    }


    internal IEnumerable<Job> GetJobsByContractorId(int contractorId)
    {
      Contractor exists = _crepo.getById(contractorId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetJobsByContractorId(contractorId);
    }


  }
}