using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crypto_wallet_ui
{
    /// <summary>
    /// Interaction logic for login_page.xaml
    /// </summary>
    public partial class login_page : Window
    {
        public login_page()
        {
            InitializeComponent();
        }

        private void Application_exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Application_minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Mousedown_event(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
