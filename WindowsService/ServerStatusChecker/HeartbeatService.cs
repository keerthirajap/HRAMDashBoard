namespace ServerStatusChecker
{
 
  


    internal class HeartbeatService : IHeartbeatService
    {
      

        public void UpdateServiceState(string state)
        {
          
        }
    }

    public interface IHeartbeatService
    {
        void UpdateServiceState(string state);
    }
}