using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Log4NetTest
{
    public static class Log4NetUtility
    {
        /// <summary>
        ///     写日志
        /// </summary>

        public static void WriteLog(this string message, string name, Log4NetType logType = Log4NetType.Info)
        {
            var log = GetLog(name);
            if (log == null)
            {
                return;
            }

            if (logType == Log4NetType.Debug)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Error)
            {
                log.Error(message);
                return;
            }

            if (logType == Log4NetType.Fatal)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Info)
            {
                log.Info(message);
                return;
            }

            log.Warn(message);
        }

        /// <summary>
        ///     写异常日志
        /// </summary>
        public static void WriteLog(this Exception exception, string name)
        {
            var log = GetLog(name);
            if (log == null)
            {
                return;
            }

            WriteLog(exception, log);
        }

        /// <summary>
        ///     写异常日志
        /// </summary>
        private static void WriteLog(Exception exception, ILog log)
        {
            if (exception == null)
            {
                return;
            }

            log.Error(exception);

            WriteLog(exception.InnerException, log);
        }

        /// <summary>
        ///     获取日志对象
        /// </summary>
        public static ILog GetLog(string name)
        {
            var logger = LogManager.GetLogger(name);
            return logger;
        }
    }

    /// <summary>
    ///     Log4Net类型枚举
    /// </summary>
    public enum Log4NetType
    {
        /// <summary>
        ///     字段Debug
        /// </summary>

        Debug,

        /// <summary>
        ///     字段Error
        /// </summary>
        Error,

        /// <summary>
        ///     字段Info
        /// </summary>
        Info,

        /// <summary>
        ///     字段Fatal
        /// </summary>
        Fatal,

        /// <summary>
        ///     字段Warn
        /// </summary>
        Warn
    }

    /// <summary>
    ///     类名称：Log4NetName
    ///     命名空间：DaiShu.Crm.Utility
    ///     类功能：日志名称
    /// </summary>
    public class Log4NetName
    {
        /// <summary>
        ///     字段UrlFilter
        /// </summary>     
        public const string Log4NetTest = "Log4NetTest";

        /// <summary>
        ///     字段UrlFilter
        /// </summary>       
        public const string UrlFilter = "RYJ.Crm.UrlFilter";

        /// <summary>
        ///     字段System
        /// </summary>      
        public const string System = "RYJ.Crm.System";

        /// <summary>
        ///     字段Quartz
        /// </summary>       
        public const string Quartz = "RYJ.Crm.Quartz";

        /// <summary>
        ///     字段Service
        /// </summary>       
        public const string Service = "RYJ.Crm.Services";

        /// <summary>
        ///     字段ExternalService
        /// </summary>     
        public const string ExternalService = "RYJ.Crm.ExternalService";

        /// <summary>
        ///     字段Return
        /// </summary>     
        public const string Return = "RYJ.Return";

        /// <summary>
        ///     字段HeartBeat
        /// </summary>       
        public const string HeartBeat = "RYJ.Crm.HeartBeat";

        /// <summary>
        /// 字段Event
        /// </summary>      
        public const string Event = "RYJ.Crm.Event";
    }
}