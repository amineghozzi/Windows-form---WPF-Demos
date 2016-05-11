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

namespace Serveur1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread th = new Thread(GetOpen);
            th.Start();
        }
            
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Socket Soc1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Soc1.Connect("127.0.0.1", 6000);
            Byte[] delimite = BitConverter.GetBytes(Encoding.UTF8.GetByteCount(txt.Text));
            Soc1.Send(delimite);
            byte[] bsend = Encoding.UTF8.GetBytes(txt.Text);
            Soc1.Send(bsend);
            Soc1.Close();
            lst.Items.Add("vous:" + txt.Text);
        }
        //byte[] bt = new byte[256];
        void GetOpen()
        {
            while (true)
            {
                Socket SocCnx = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket SocClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint Server = new IPEndPoint(IPAddress.Any, 5000);
                SocCnx.Bind(Server);
                SocCnx.Listen(10);
                SocClient = SocCnx.Accept();
                byte[] nbbyte = new byte[sizeof(Int32)];
                SocClient.Receive(nbbyte,4,SocketFlags.None);
                int byteLire = BitConverter.ToInt32(nbbyte, 0);
               
                byte[] bt = new byte[byteLire];
                SocClient.Receive(bt);
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    lst.Items.Add(Encoding.UTF8.GetString(bt));
                });
                SocClient.Close();
                SocCnx.Close();
            }
        }
    }
}
