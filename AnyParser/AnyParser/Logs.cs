using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using Microsoft.Win32.SafeHandles;

namespace Logging
{
    enum LogLevel
    {
        NORMAL,
        ERROR,
        WARNING,
        VERBOSE,
        DEBUG
    }
    enum Categories
    {
        Program,
        Ihm
    }
    class LogLine : EventArgs
    {
        private string _date;
        private LogLevel _level;
        private Categories _category;
        private string _message;

        #region Default Constructor
        public LogLine(LogLevel level, Categories cat, string message)
        {
            this._date = DateTime.Now.ToString();
            this._level = level;
            this._category = cat;
            this._message = message;
        }
        #endregion

        #region Properties
        public string Date
        {
            get { return this._date; }
        }

        public LogLevel Level
        {
            get { return this._level; }
        }

        public Categories Category
        {
            get { return this._category; }
        }

        public string Message
        {
            get { return this._message; }
        }
        #endregion

        public override string ToString()
        {
            return this._date + ";" + this._level.ToString() + ";" + this._category.ToString() + ";" + this._message;
        }
    }

    static class Logs
    {
        private static SynchronizationContext _formContext;
        private static ManualResetEvent _threadToStop;
        private static AutoResetEvent _NewLog;
        private static Mutex _mutualExclusion;
        private static Thread _tLogsViewer;
        private static Stack<LogLine> _stack;

        public static event EventHandler<LogLine> PrintLog;

        private static void ThreadProc()
        {
            while (true)
            {

                if (WaitHandle.WaitAny(new WaitHandle[] { Logs._NewLog, Logs._threadToStop }) == 1) break;
                //Logs._mutualExclusion.WaitOne();
                while(Logs._stack.Count > 0)
                {
                    LogLine line = Logs._stack.Pop();
                    Logs._formContext.Post(new SendOrPostCallback(delegate(object passLine)
                    {
                        Logs.PrintLog(null, passLine as LogLine);
                    }), line);
                }
                //Logs._mutualExclusion.ReleaseMutex();
            }
        }

        public static void Initialize()
        {
            Logs._threadToStop = new ManualResetEvent(false);
            Logs._NewLog = new AutoResetEvent(false);
            Logs._mutualExclusion = new Mutex();
            Logs._tLogsViewer = new Thread(new ThreadStart(ThreadProc));
            Logs._stack = new Stack<LogLine>();
            Logs._formContext = SynchronizationContext.Current;
            Logs._tLogsViewer.Start();
        }

        public static void Send(LogLevel level, Categories cat, string message)
        {
            //Logs._mutualExclusion.WaitOne();
            Logs._stack.Push(new LogLine(level, cat, message));
            //Logs._mutualExclusion.ReleaseMutex();
            Logs._NewLog.Set();
        }

        public static void Release()
        {
            Logs._threadToStop.Set();
            Logs._tLogsViewer.Join();
        }
    }
}
