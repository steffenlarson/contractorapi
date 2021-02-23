using System;
using System.Collections.Generic;
using contractorapi.Models;
using contractorapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorapi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class JobsController : ControllerBase
  {

    private readonly JobsService _js;


    public JobsController(JobsService js)
    {
      _js = js;
    }




    // GET api/Jobs
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/Jobs/5
    [HttpGet("{id}")]
    public ActionResult<Job> getById(int id)
    {
      try
      {
        return Ok(_js.getByID(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/Jobs
    [HttpPost]
    public ActionResult<Job> Post([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/Jobs/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_js.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




    [HttpPut("{id}")]
    public ActionResult<Job> Edit([FromBody] Job editJob, int id)
    {
      try
      {
        editJob.Id = id;
        return Ok(_js.Edit(editJob));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}