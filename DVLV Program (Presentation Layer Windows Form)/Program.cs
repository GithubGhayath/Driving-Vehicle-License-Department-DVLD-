using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLV_Program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        //For Login Screen if "OpenNewFormOnClose" == true will open login form again else will not open
        public static bool OpenNewFormOnClose { get; set; }
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmStartScreen());
            OpenNewFormOnClose = false;

            //Application.Run(new frmTest());

            Application.Run(new frmLoginScreen());

            if (OpenNewFormOnClose)
            {
                Application.Run(new frmLoginScreen());
            }

        }
    }
}
