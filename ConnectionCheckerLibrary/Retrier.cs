using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace ConnectionCheckerLibrary {

    /// <summary>
    /// Attempts connecting until it gets a positive result, then sends the message to the UI.
    /// </summary>
    public class Retrier {
        private Timer timer;
        public EventHandler ConnectionIsBack;

        public Retrier(long milliseconds = 1000) {
            timer = new Timer(milliseconds);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            if(ConnectionHandler.AttemptConnection()) {
                timer.Stop();
                ConnectionIsBack?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
