using System;
using System.Collections.Generic;
using contract_job.Models;
using contract_job.Repositories;

namespace contract_job.Services
{
  public class JobsService
  {
      private readonly JobsRepository _jRepo;
      private readonly ContractorsRepository _cRepo;

    public JobsService(JobsRepository jRepo, ContractorsRepository cRepo)
    {
      _jRepo = jRepo;
      _cRepo = cRepo;
    }

    internal IEnumerable<Job> GetAll()
    {
      return _jRepo.GetAll();
    }

    internal Job GetOne(int id)
    {
        Job exists = _jRepo.GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return exists;
    }

    internal IEnumerable<Job> GetJobs(int id)
    {
      Contractor exists = _cRepo.GetOne(id);
      if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return _jRepo.GetJobs(id);
    }

    internal Job Create(Job newJob)
    {
        int id = _jRepo.Create(newJob);
        newJob.id = id;
        return newJob;
    }

    internal Job Edit(int id, Job editJob)
    {
        Job exists = GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        editJob.id = id;
        return _jRepo.Edit(editJob);
    }

    internal string Delete(int id)
    {
        Job exists = GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return _jRepo.Delete(id);
    }


  }
}