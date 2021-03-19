using System.Collections.Generic;

namespace SignalRSampleService.Hubs.Handlers
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }
}
