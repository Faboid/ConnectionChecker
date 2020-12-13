using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace ConnectionCheckerLibrary {
    public static class ConnectionHandler {

        public static bool AttemptConnection() {
            try {
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8");
                return reply.Status == IPStatus.Success;
            } catch {
                return false;
            }
        }


    }
}
