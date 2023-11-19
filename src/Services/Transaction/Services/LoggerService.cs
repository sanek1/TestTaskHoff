using log4net.Config;
using log4net;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Transaction.WebApi.Services.Interface;

namespace Transaction.WebApi.Services
{
    public class LoggerService : ILoggerService
    {
        private static ILog log = LogManager.GetLogger("LOGGER");
        public static ILog Log
        {
            get { return log; }
        }

        public void SetLog(string message) {
            Log.Info(message);
        }
        public void InitLogger()
        {
            var path = Directory.GetCurrentDirectory();
            XmlConfigurator.Configure(new System.IO.FileInfo(path+"\\TestConf.xml"));
        }
    }
}
