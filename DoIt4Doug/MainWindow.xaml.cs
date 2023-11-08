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
using Sres.Net.EEIP;
using System.ComponentModel;
using System.Threading;


namespace DoIt4Doug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    


    public partial class MainWindow : Window
    {
        static string[] tagsFile;
        static int tagIndex = 0;
        static string currentTag = "";
        static bool isRemote = false;
        static string controllerType = "";
        static string ipAddress;
        EIPDataHandler handler = new EIPDataHandler();
        //add Components



        List<Sres.Net.EEIP.Encapsulation.CIPIdentityItem> CIPList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void getDataBtn_Click(object sender, RoutedEventArgs e)
        {
            ipAddress = ipAddressTxtBx.Text;

            try
            {
                handler.Connect(ipAddress);
            }
            catch { Console.WriteLine("connection failed"); }
        }
    }
}
