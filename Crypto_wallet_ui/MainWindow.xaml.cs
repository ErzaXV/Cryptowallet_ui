using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Crypto_wallet_ui
{
    public partial class MainWindow : Window
    {
        bool mousedown;
        private Point offset;

        public MainWindow()
        {
            InitializeComponent();
            getinfo();
        }
        private async void getinfo()
        {
           
            using (var client = new HttpClient())
            {
               string apikey = "851643a9eb63ac287f91812b4ef31d29bd7d0f94d2ddb7d72c7eca2da0f99845";
               string market = "cadli";
               string instruments = "BTC-USD,ETH-USD,XMR-USD,LTC-USD,USDT-USD,SOL-USD";
               var url = $"https://data-api.coindesk.com/index/cc/v1/latest/tick?market={market}&apply_mapping=true&instruments={instruments}&api_key={apikey}";

                try
                {
                    string json = await client.GetStringAsync(url);
                    var info = JsonConvert.DeserializeObject<Pricedata_info.root>(json);

                    BitmapImage up = new BitmapImage(new Uri(@"/images2/up.png", UriKind.Relative));
                    BitmapImage down = new BitmapImage(new Uri(@"/images2/down.png", UriKind.Relative));
                    if (info != null)
                    {
                        btcprice.Text = $"${price(info.BTCUSD.VALUE)}";
                        ethprice.Text = $"${UptoTwoDecimalPoints(info.ETHUSD.VALUE)}";
                        ltcprice.Text = $"${UptoTwoDecimalPoints(info.LTCUSD.VALUE)}";
                        mnreprice.Text = $"${UptoTwoDecimalPoints(info.XMRUSD.VALUE)}";
                        usdtprice.Text = $"${UptoTwoDecimalPoints(info.USDTUSD.VALUE)}";
                        slnprice.Text = $"${UptoTwoDecimalPoints(info.SOLUSD.VALUE)}";

                        btcstatus.Text = (info.BTCUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";
                        ethstatus.Text = (info.ETHUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";
                        ltcstatus.Text = (info.LTCUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";
                        xmrstatus.Text = (info.XMRUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";
                        usdtstatus.Text = (info.USDTUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";
                        solstatus.Text = (info.SOLUSD.VALUE_FLAG == "UP") ? "UP" : "DOWN";

                        Btcstatuspic.Source = (info.BTCUSD.VALUE_FLAG == "UP") ? up : down;
                        ethstatispic.Source = (info.ETHUSD.VALUE_FLAG == "UP") ? up : down;
                        ltcstatuspic.Source = (info.LTCUSD.VALUE_FLAG == "UP") ? up : down;
                        xmrstatuspic.Source = (info.XMRUSD.VALUE_FLAG == "UP") ? up : down;
                        usdtstatuspic.Source = (info.USDTUSD.VALUE_FLAG == "UP") ? up : down;
                        solstatuspic.Source = (info.SOLUSD.VALUE_FLAG == "UP") ? up : down;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public double UptoTwoDecimalPoints(double num)
        {
            var totalCost = Convert.ToDouble(String.Format("{0:0.00}", num));
            return totalCost;
        }

        public string price(double db_price)
        {
            int intprice = (int)db_price;
            string stprcie = intprice.ToString();
            return stprcie;
        }


        private void Mousedown_event(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Application_exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Application_minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            login_page Login_Page = new login_page();
            Login_Page.Show();
        }
    }
}