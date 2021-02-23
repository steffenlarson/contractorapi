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

    internal Contractor getByID(int id)
    {
      Contractor exists = _repo.getById(id);
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
      getByID(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }


    internal Contractor Edit(Contractor editContractor)
    {
      Contractor original = getByID(editContractor.Id);

      original.Name = editContractor.Name != null ? editContractor.Name : original.Name;
      original.Description = editContractor.Description != null ? editContractor.Description : original.Description;

      return _repo.Edit(original);
    }


  }
}