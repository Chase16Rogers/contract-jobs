using System.Collections.Generic;
using contract_job.Models;
using contract_job.Services;
using Microsoft.AspNetCore.Mvc;

namespace contract_job.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _CS;
        private readonly JobsService _JS;

    public ContractorsController(ContractorsService cS, JobsService jS)
    {
      _CS = cS;
      _JS = jS;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
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
    public ActionResult<Contractor> Get(int id)
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

    [HttpGet("{id}/jobs")]
    public ActionResult<IEnumerable<Job>> GetJobs(int id)
    {
        try
        {
            return Ok(_JS.GetJobs(id));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
        try
        {
            return Ok(_CS.Create(newContractor));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit(int id, [FromBody] Contractor editContractor)
    {
        try
        {
            return Ok(_CS.Edit(id, editContractor));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
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