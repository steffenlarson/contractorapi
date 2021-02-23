using System;
using System.Collections.Generic;
using contractorapi.Models;
using contractorapi.Repositories;


namespace contractorapi.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;


    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }



    internal IEnumerable<Contractor> Get()
    {
      return _repo.Get();
    }
    internal Contractor Get(int id)
    {
      Contractor exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Contractor Create(Contractor newContractor)
    {
      int id = _repo.Create(newContractor);
      newContractor.Id = id;
      return newContractor;
    }


    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }



  }
}