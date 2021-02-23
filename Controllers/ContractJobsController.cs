using contract_job.Models;
using contract_job.Services;
using Microsoft.AspNetCore.Mvc;

namespace contract_job.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractJobsController : ControllerBase
    {
        private readonly ContractJobsService _CJS;

    public ContractJobsController(ContractJobsService cJS)
    {
      _CJS = cJS;
    }

    [HttpPost]
    public ActionResult<ContractJob> Create([FromBody] ContractJob newContractJob)
    {
        try
        {
            return Ok(_CJS.Create(newContractJob));
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
            return Ok(_CJS.Delete(id));
        }
        catch (System.Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    }
}