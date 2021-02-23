using System;
using System.Collections.Generic;
using System.Data;
using contract_job.Models;
using Dapper;

namespace contract_job.Repositories
{
  public class JobsRepository
  {
      public readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> GetAll()
    {
        string sql = "SELECT * FROM jobs";
        return _db.Query<Job>(sql);
    }

    internal Job GetOne(int id)
    {
        string sql = "SELECT * FROM jobs WHERE id = @id;";
        return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal IEnumerable<Job> GetJobs(int id)
    {
      string sql = @"
      SELECT j.*,
      cj.id as contractJobId
      FROM contractjobs cj
      JOIN jobs j ON j.id = cj.jobId
      WHERE jobId = @id;
      ";
      return _db.Query<JobContractorView>(sql, new { id });
    }

    internal int Create(Job newJob)
    {
        string sql = @"
        INSERT INTO jobs (task, rate) VALUES (@task, @rate);
        SELECT LAST_INSERT_ID();";
        return _db.ExecuteScalar<int>(sql, newJob);
    }

    internal Job Edit(Job editJob)
    {
        string sql = "UPDATE jobs SET task = @task, rate = @rate WHERE id = @id;";
        _db.Execute(sql, editJob);
        return editJob;
    }



    internal string Delete(int id)
    {
        string sql = "DELETE FROM jobs WHERE id = @id;";
        _db.Execute(sql, new { id });
        return "Gone boss!";
    }
  }
}