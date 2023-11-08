using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sres.Net.EEIP;
using System.ComponentModel;

namespace DoIt4Doug
{
    class EIPDataHandler
    {
        static string eipConnectionInfo = "";
        EEIPClient eipClient = new EEIPClient();
        BackgroundWorker worker = new BackgroundWorker();
        string lastConnection = "";
        List<Sres.Net.EEIP.Encapsulation.CIPIdentityItem> cipIdentityItem;

        //private List<CustomControl.BitsControl> outputBitsList = new List<CustomControl.BitsControl>();
        //private List<CustomControl.BytesControl> outputBytesList = new List<CustomControl.BytesControl>();

        bool isConnected = false;

        int[] inputByteToInt;
        byte[] outputIntToByte;

        public EIPDataHandler()
        {

        }

        /*Connect method will establish connections.
         * 1) Checks if it's already connected. If it is, return/exit method.
         * 2) takes the provided ipAddress and uses it to register a new connection
         * 3) sets the necessary parameters for the systems. This code can be found in the eeip website
         * 4) Creates a string  to be displayed on the connection text box. This will first be passed back
         * to MainScreen
         */
        public string Connect(string ipAddress)
        {
            string returnString = "";
            // 1)
            if (isConnected == true)
                return returnString = "Already Connected.";
            isConnected = true;

            // 2)
            eipClient.IPAddress = ipAddress;
            try
            {
                eipClient.RegisterSession();
            }
            catch 
            {
                Console.WriteLine("failed to register session");
                return "";
            }
            

            // 3)
            // Originatore = PC, Target = CVX
            eipClient.O_T_InstanceID = 0x65; //Instance ID of CVX Input Assembly (101)
            eipClient.O_T_Length = eipClient.Detect_O_T_Length();

            inputByteToInt = new int[eipClient.O_T_Length];
            // UI.drawAssembly(eip.Client.O_T_Length)

            //query to see if CVX can tell if SINT INT or DINT
            //check manual

            Console.WriteLine(eipClient.O_T_Length);

            return returnString;
        }
    }
}
