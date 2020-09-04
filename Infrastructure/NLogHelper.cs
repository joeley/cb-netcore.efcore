using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class NLogHelper
    {
        //每创建一个Logger都会有一定的性能损耗，所以定义静态变量
        //private static Logger nLogger = LogManager.GetCurrentClassLogger();

        private static Logger nLogger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

        /// <summary>
        /// 打印Info 日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            nLogger.Info(msg);
        }

        /// <summary>
        /// 打印Erro 日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Error(string msg, Exception ex = null)
        {
            if (ex == null)
                nLogger.Error(msg);
            else
                nLogger.Error(ex, msg);
        }

        /// <summary>
        /// 打印Debugger日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Debugger(string msg)
        {
            nLogger.Debug(msg);
        }
    }
}
