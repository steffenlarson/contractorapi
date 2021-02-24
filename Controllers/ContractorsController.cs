using System;
using System.Collections.Generic;
using contractorapi.Models;
using contractorapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorapi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class ContractorsController : ControllerBase
  {

    private readonly ContractorsService _cs;
    private readonly JobsService _js;


    public ContractorsController(ContractorsService cs, JobsService js)
    {
      _cs = cs;
      _js = js;
    }




    // GET api/Contractors
    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/Contractors/5
    [HttpGet("{id}")]
    public ActionResult<Contractor> getById(int id)
    {
      try
      {
        return Ok(_cs.getByID(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/Contractors
    [HttpPost]
    public ActionResult<Contractor> Post([FromBody] Contractor newContractor)
    {
      try
      {
        return Ok(_cs.Create(newContractor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/Contractors/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_cs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor editContractor, int id)
    {
      try
      {
        editContractor.Id = id;
        return Ok(_cs.Edit(editContractor));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }



    [HttpGet("{contractorId}/contractorjobs")]
    public ActionResult<IEnumerable<Job>> GetContractorJobs(int contractorId)
    {
      try
      {
        return Ok(_js.GetJobsByContractorId(contractorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}