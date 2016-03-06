using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingClassLibrary
{
    public static class Logger
    {
        /// <summary>
        /// エラーログ出力用
        /// </summary>
        private static NLog.Logger ErrorLogger = LogManager.GetLogger("ErrorLogger");

        /// <summary>
        /// 情報ログ出力用
        /// </summary>
        private static NLog.Logger InfoLogger = LogManager.GetLogger("InfoLogger");

        /// <summary>
        /// デバッグログ出力用
        /// </summary>
        private static NLog.Logger DebugLogger = LogManager.GetLogger("DebugLogger");

        /// <summary>
        /// エラーログを出力
        /// </summary>
        /// <param name="_ex">例外</param>
        public static void WriteErrorLog(Exception _ex)
        {
            ErrorLogger.Error(_ex, _ex.Message);
        }

        /// <summary>
        /// 情報ログを出力
        /// </summary>
        /// <param name="_message">メッセージ</param>
        public static void WriteInfoLog(string _message)
        {
            InfoLogger.Info(_message);
        }

        /// <summary>
        /// デバッグログを出力
        /// </summary>
        /// <param name="_message">メッセージ</param>
        public static void WriteDebugLog(string _message)
        {
            #if DEBUG
            DebugLogger.Debug(_message);
            #endif
        }
    }
}
