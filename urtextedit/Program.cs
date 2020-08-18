using System;
using System.Windows.Forms;


using Microsoft.VisualBasic.ApplicationServices;

namespace urtextedit
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static string fname = string.Empty;
        [STAThread]

        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();



            if (args.Length > 1)
            {
                fname = args[1];
            }

            SingleInstanceController controller = new SingleInstanceController();
            controller.Run(args);
        

        }

        public class SingleInstanceController : WindowsFormsApplicationBase
        {
            public SingleInstanceController()
            {
                IsSingleInstance = true;

                StartupNextInstance += this_StartupNextInstance;
            }

            void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                mEditor form = MainForm as mEditor; //My derived form type
                form.Activate();                
                form.CreateTab(e.CommandLine[1]);

            }

            protected override void OnCreateMainForm()
            {
                MainForm = new mEditor(fname);
            }
        }

    }
}
