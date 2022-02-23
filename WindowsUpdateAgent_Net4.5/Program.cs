using System.ServiceProcess;

namespace WindowsUpdateAgent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WindowsUpdateAgent()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
