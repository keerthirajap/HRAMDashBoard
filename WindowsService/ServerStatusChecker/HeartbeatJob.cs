using System;

using Common.Logging;
using Quartz;

public class HeartbeatJob : IJob
{
    private readonly IHeartbeatService _hearbeat;
    private static readonly ILog s_log = LogManager.GetLogger<HeartbeatJob>();

    public HeartbeatJob(IHeartbeatService hearbeat)
    {
        if (hearbeat == null) throw new ArgumentNullException(nameof(hearbeat));
        _hearbeat = hearbeat;
    }

    public void Execute(IJobExecutionContext context)
    {
        _hearbeat.UpdateServiceState("alive");
    }
}
