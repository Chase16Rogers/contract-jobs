using System;
using System.Data;
using contract_job.Models;
using Dapper;

namespace contract_job.Repositories
{
    public class ContractJobsRepository
    {
        public readonly IDbConnection _db;

    public ContractJobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal ContractJob GetOne(int id)
    {
      string sql = "SELECT * FROM contractjobs WHERE id = @id";
      return _db.QueryFirstOrDefault<ContractJob>(sql, new { id });
    }

    internal int Create(ContractJob newCj)
    {
        string sql = @"
        INSERT INTO contractjobs (jobId, contractorId) VALUES (@jobId, @contractorId);
        SELECT LAST_INSERT_ID();";
        return _db.ExecuteScalar<int>(sql, newCj);
    }

    internal string Delete(int id)
    {
      string sql = "DELETE FROM contractjobs WHERE id = @id";
      _db.Execute(sql, new { id });
      return "Gone Boss!";
    }
  }
}