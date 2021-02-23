using System;
using System.Collections.Generic;
using contract_job.Models;
using contract_job.Repositories;

namespace contract_job.Services
{
  public class ContractorsService
  {
      private readonly ContractorsRepository _cRepo;
      private readonly JobsRepository _jRepo;

    public ContractorsService(ContractorsRepository cRepo, JobsRepository jRepo)
    {
      _cRepo = cRepo;
      _jRepo = jRepo;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      return _cRepo.GetAll();
    }

    internal Contractor GetOne(int id)
    {
        Contractor exists = _cRepo.GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return exists;
    }

    internal IEnumerable<Contractor> GetContractors(int id)
    {
      Job exists =_jRepo.GetOne(id);
       if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return _cRepo.GetContractors(id);
    }

    internal Contractor Create(Contractor newContractor)
    {
        int id = _cRepo.Create(newContractor);
        newContractor.id = id;
        return newContractor;
    }

    internal Contractor Edit(int id, Contractor editContractor)
    {
        Contractor exists = GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        editContractor.id = id;
        return _cRepo.Edit(editContractor);
    }



    internal string Delete(int id)
    {
        Contractor exists = GetOne(id);
        if (exists == null)
        {
            throw new Exception("Id gave us nothing boss");
        }
        return _cRepo.Delete(id);
    }
  }
}