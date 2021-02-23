using System;
using contractorapi.Services;
using Microsoft.AspNetCore.Mvc;
using contractorapi.Models;


namespace contractorapi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class ContractorJobsController : ControllerBase
  {

    private readonly ContractorJobsService _cjs;

    public ContractorJobsController(ContractorJobsService cjs)
    {
      _cjs = cjs;
    }


    [HttpPost]
    public ActionResult<ContractorJobs> Post([FromBody] ContractorJobs newCj)
    {
      try
      {
        return Ok(_cjs.Create(newCj));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_cjs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




  }
}