using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ArrowPointCANBusTool.Transfer
{
    static class TransferScheduler
    {
        private static IScheduler scheduler;

        public static async Task RunTransfer(int minuteInterval)
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<TransferJob>()
                    .WithIdentity("TransferJob1", "TransferJobsGroup")
                    .Build();

                // Check so we are not double scheduling
                if (!scheduler.CheckExists(job.Key).Result)
                {
                    // Trigger the job to run now, and then repeat every 10 seconds
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity("TransferJobTrigger1", "TransferJobsGroup")
                        .StartNow()
                        .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(minuteInterval)
                            .RepeatForever())
                        .Build();

                    // Tell quartz to schedule the job using our trigger
                    await scheduler.ScheduleJob(job, trigger);
                }

                await Console.Out.WriteLineAsync("Job Scheduled!");

                // and last shut down the scheduler when you are ready to close your program
                //await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        public static void StopTransfer()
        {            
            scheduler?.Shutdown();
            Console.Out.WriteLineAsync("Scheduler Stopped");
        }

    }
}
