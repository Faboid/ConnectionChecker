using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace ConnectionCheckerLibrary {

    /// <summary>
    /// Attempts connecting until it gets a positive result, then triggers a "ConnectionIsBack" event.
    /// </summary>
    public class Retrier {
        private Timer timer;
        public event EventHandler ConnectionIsBack;

        //note: this could be refactored to fire Timer_Elapsed instantly for the first time, 
        //but I've left it as it is because this application is meant to be used when the internet connection is absent
        //with the purpose of warning the user only once the connection returns.
        public Retrier(long milliseconds = 10000) {
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
