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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Windows.Threading;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Thread(getOpen).Start();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           
        }
        void getOpen()
        {
            while (true)
            {
                Socket socCnx = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint Server = new IPEndPoint(IPAddress.Any, 7500);
                socCnx.Bind(Server);
                socCnx.Listen(10);
                socClient = socCnx.Accept();
                byte[] delimiteur = new byte[sizeof(Int32)];
                socClient.Receive(delimiteur, 4, SocketFlags.None);
                int ctr = BitConverter.ToInt32(delimiteur, 0);
                byte[] bt = new byte[ctr];
                socClient.Receive(bt);
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    lst.Items.Add(Encoding.UTF8.GetString(bt));
                });
                socClient.Close();
                socCnx.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soc.Connect("127.0.0.1", 6000);
            byte[] bt = BitConverter.GetBytes(Encoding.UTF8.GetByteCount(txt.Text));
            soc.Send(bt);
            byte[]bsend=Encoding.UTF8.GetBytes(txt.Text);
            soc.Send(bsend);
            soc.Close();
            lst.Items.Add(txt.Text);
        }
    }
}
