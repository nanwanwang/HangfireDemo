using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using HangfireWeb.HangfireJobs;
using Microsoft.AspNetCore.Mvc;

namespace HangfireWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            AddJob();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                int a = 0;
                var res = 5 / a;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RemoveJob();
        }
        private void AddJob()
        {
            RecurringJob.AddOrUpdate("testjob",() => new Job().Execute(), Cron.Minutely);
            RecurringJob.AddOrUpdate("testjob2", () => new Job().Execute2(), Cron.Minutely);
            RecurringJob.AddOrUpdate("testjob3", () => new Job().Execute3(), Cron.Minutely);
            RecurringJob.AddOrUpdate("testjob4", () => new Job().Execute4(), Cron.Minutely);
            RecurringJob.AddOrUpdate("testjob5", () => new Job().Execute5(), Cron.Minutely);
            RecurringJob.AddOrUpdate("testjob6", () => new Job().Execute6(), Cron.Minutely);
        }

        private void RemoveJob()
        {
            RecurringJob.RemoveIfExists("testjob");
            RecurringJob.RemoveIfExists("testjob4");
            RecurringJob.RemoveIfExists("testjob5");
            RecurringJob.RemoveIfExists("testjob6");
        }
    }
}
