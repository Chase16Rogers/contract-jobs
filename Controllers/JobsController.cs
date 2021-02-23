using System.Collections.Generic;
using contract_job.Models;
using contract_job.Services;
using Microsoft.AspNetCore.Mvc;

namespace contract_job.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _CS;
        private readonly ContractorsService _JS;

    public JobsController(JobsService cS, ContractorsService jS)
    {
      _CS = cS;
      _JS = jS;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
        try
        {
            return Ok(_CS.GetAll());
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
        try
        {
            return Ok(_CS.GetOne(id));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{id}/contractors")]
    public ActionResult<Job> GetJobs(int id)
    {
        try
        {
            return Ok(_JS.GetContractors(id));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
        try
        {
            return Ok(_CS.Create(newJob));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Edit(int id, [FromBody] Job editJob)
    {
        try
        {
            return Ok(_CS.Edit(id, editJob));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<Job> Delete(int id)
    {
        try
        {
            return Ok(_CS.Delete(id));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    }
}