namespace ServerStatus
{
    using Common.Logging;

    internal class HeartbeatService : IHeartbeatService
    {
        private static readonly ILog s_log = LogManager.GetLogger<HeartbeatService>();

        public void UpdateServiceState(string state)
        {
            s_log.InfoFormat("Service state: {0}.", state);
        }
    }

    public interface IHeartbeatService
    {
        void UpdateServiceState(string state);
    }
}