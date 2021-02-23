using contract_job.Models;
using contract_job.Repositories;
using System;

namespace contract_job.Services
{
    public class ContractJobsService
    {
    private readonly ContractJobsRepository _repo;

    public ContractJobsService(ContractJobsRepository repo)
    {
      _repo = repo;
    }

    internal ContractJob Create(ContractJob newContractor)
    {
        int id = _repo.Create(newContractor);
        newContractor.id = id;
        return newContractor;
    }
    internal string Delete(int id)
    {
        ContractJob exists = _repo.GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return _repo.Delete(id);
    }
    }
}