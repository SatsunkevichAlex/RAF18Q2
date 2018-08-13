using log4net;
using log4net.Config;
using System;

namespace FifaWorldcup.Test.Automation.Framework.CORE
{
    public class Logger
    {
        private ILog Log { get; set; }

        public Logger(Type type)
        {
            XmlConfigurator.Configure();
            this.Log = LogManager.GetLogger(type.Name);
        }

        public void Info(object message)
        {
            this.Log.Info(message);
        }

        public void Info(string message)
        {
            this.Log.Info(message);
        }

        public void Info(object message, params object[] parameters)
        {
            this.Log.Info($"{message} {parameters}");
        }

        public void Error(object message, params object[] parameters)
        {
            this.Log.Error($"{message} {parameters}");
        }

        public void Error(string msg, Exception ex)
        {
            this.Log.Error(msg, ex);
        }

        public void Debug(object msg)
        {
            this.Log.Debug(msg);
        }

        public void Debug(object msg, Exception ex)
        {
            this.Log.Debug(msg, ex);
        }

        public void Debug(Exception ex)
        {
            this.Log.Debug(ex.Message, ex);
        }
    }
}