using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.Services;

namespace VMSCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IDummyEmailService _dummyEmailService = null;
        public EmailController(IDummyEmailService dummyEmailService)
        {
            _dummyEmailService = dummyEmailService;
        }

        [HttpGet]
        public string InitSendMail()
        {
            _dummyEmailService.SendEmail("Direct Call", DateTime.Now.ToLongTimeString());//thực thi chi tiết gửi mail

            BackgroundJob.Enqueue(() => _dummyEmailService.SendEmail("Fire-and-Forget Job", DateTime.Now.ToLongTimeString()));

            BackgroundJob.Schedule(() => _dummyEmailService.SendEmail("Delayed Job", DateTime.Now.ToLongTimeString()), TimeSpan.FromSeconds(30));

            RecurringJob.AddOrUpdate(() => _dummyEmailService.SendEmail("Recurring Job", DateTime.Now.ToLongTimeString()), Cron.Minutely);

            var jobId = BackgroundJob.Schedule(() => _dummyEmailService.SendEmail("Continuation Job 1", DateTime.Now.ToLongTimeString()), TimeSpan.FromSeconds(10));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuation Job 2 - Email Reminder - " + DateTime.Now.ToLongTimeString()));

            return "Email Initiated";
        }
    }
}
