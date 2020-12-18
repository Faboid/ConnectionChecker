using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConnectionCheckerLibrary;

namespace ConnectionCheckerUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Retrier connectionAttempt;

        public MainWindow() {
            InitializeComponent();
            CallLibraryLogic();
        }

        private void CallLibraryLogic() {
            connectionAttempt = new Retrier();
            connectionAttempt.ConnectionIsBack += ConnectionWorks;
        }

        private void ConnectionWorks(object sender, EventArgs e) {
            EditDisplayText("The internet connection functions as normal.");
            PlaySound();
        }

        private void EditDisplayText(string text) {
            if(!Dispatcher.CheckAccess()) {
                Dispatcher.Invoke(new Action(() => EditDisplayText(text) ));
            } else {
                DisplayText.Text = text;
            }
        }

        private void PlaySound() {
            SoundPlayer player = new SoundPlayer(Properties.Resources.The_Wandering_Loop);
            player.Play();
        }
    }
}
