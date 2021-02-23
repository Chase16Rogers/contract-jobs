using System;
using System.Collections.Generic;
using System.Data;
using contract_job.Models;
using Dapper;

namespace contract_job.Repositories
{
  public class ContractorsRepository
  {
      public readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Contractor> GetAll()
    {
        string sql = "SELECT * FROM contractors";
        return _db.Query<Contractor>(sql);
    }

    internal Contractor GetOne(int id)
    {
        string sql = "SELECT * FROM contractors WHERE id = @id;";
        return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal IEnumerable<Contractor> GetContractors(int id)
    {
      string sql = @"
      SELECT c.*,
      cj.id as contractJobId
      FROM contractjobs cj
      JOIN contractors c ON c.id = cj.contractorId
      WHERE jobId = @id;";
      return _db.Query<ContractorJobView>(sql, new { id });
    }

    internal int Create(Contractor newContractor)
    {
        string sql = @"
        INSERT INTO contractors (name, phone) VALUES (@name, @phone);
        SELECT LAST_INSERT_ID();";
        return _db.ExecuteScalar<int>(sql, newContractor);
    }

    internal Contractor Edit(Contractor editContractor)
    {
        string sql = "UPDATE contractors SET name = @name, phone = @phone WHERE id = @id;";
        _db.Execute(sql, editContractor);
        return editContractor;
    }

    internal string Delete(int id)
    {
        string sql = "DELETE FROM contractors WHERE id = @id;";
        _db.Execute(sql, new { id });
        return "Gone boss!";
    }
  }
}