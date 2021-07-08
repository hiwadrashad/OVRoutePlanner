using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Logging.SeriLogger
{
    public class Setup
    {
        public static void Startup()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("..\\Shared\\Logging\\Logs\\log.txt").CreateLogger();
        }
    }
}
