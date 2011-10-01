﻿/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using Mooege.Common.Extensions;
using Mooege.Net.GS.Message;

namespace Mooege.Common
{
    public enum Level
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
        Incoming,
        Outgoing,
    }

    public static class LogManager
    {
        public static bool Enabled { get; set; }

        internal readonly static List<Target> Targets = new List<Target>();
        internal static readonly Dictionary<string, Logger> Loggers = new Dictionary<string, Logger>();

        public static void AttachLogTarget(Target target)
        {
            Targets.Add(target);
        }

        public static Logger CreateLogger()
        {
            var frame = new StackFrame(1, false);
            var name = frame.GetMethod().DeclaringType.Name;
            if (name == null) throw new Exception("Error getting full name for declaring type.");
            if (!Loggers.ContainsKey(name)) Loggers.Add(name, new Logger(name));
            return Loggers[name];
        }

        public static Logger CreateLogger(string name)
        {
            if (!Loggers.ContainsKey(name)) Loggers.Add(name, new Logger(name));
            return Loggers[name];
        }
    }

    internal static class LogRouter
    {
        public static void RouteMessage(Level level, string logger, string message)
        {
            if (!LogManager.Enabled) return;
            if (LogManager.Targets.Count == 0) return;

            foreach (var target in LogManager.Targets.Where(target => level >= target.MinimumLevel))
            {
                target.LogMessage(level, logger, message);
            }
        }

        public static void RouteException(Level level, string logger, string message, Exception exception)
        {
            if (!LogManager.Enabled) return;
            if (LogManager.Targets.Count == 0) return;

            foreach (var target in LogManager.Targets.Where(target => level >= target.MinimumLevel))
            {
                target.LogException(level, logger, message, exception);
            }
        }
    }

    public class Logger
    {
        public string Name { get; protected set; }

        public Logger(string name)
        {
            Name = name;
        }

        private void Log(Level level, string message, object[] args)
        {
            LogRouter.RouteMessage(level, this.Name, args == null ? message : string.Format(CultureInfo.InvariantCulture, message, args));
        }

        private void LogException(Level level, string message, object[] args, Exception exception)
        {
            LogRouter.RouteException(level, this.Name, args == null ? message : string.Format(CultureInfo.InvariantCulture, message, args), exception);
        }

        public void Trace(string message) { Log(Level.Trace, message, null); }
        public void Trace(string message, params object[] args) { Log(Level.Trace, message, args); }

        public void Debug(string message) { Log(Level.Debug, message, null); }
        public void Debug(string message, params object[] args) { Log(Level.Debug, message, args); }

        public void Info(string message) { Log(Level.Info, message, null); }
        public void Info(string message, params object[] args) { Log(Level.Info, message, args); }

        public void Warn(string message) { Log(Level.Warn, message, null); }
        public void Warn(string message, params object[] args) { Log(Level.Warn, message, args); }

        public void Error(string message) { Log(Level.Error, message, null); }
        public void Error(string message, params object[] args) { Log(Level.Error, message, args); }

        public void Fatal(string message) { Log(Level.Fatal, message, null); }
        public void Fatal(string message, params object[] args) { Log(Level.Fatal, message, args); }

        public void TraceException(Exception exception, string message) { LogException(Level.Trace, message, null, exception); }
        public void TraceException(Exception exception, string message, params object[] args) { LogException(Level.Trace, message, args, exception); }

        public void DebugException(Exception exception, string message) { LogException(Level.Debug, message, null, exception); }
        public void DebugException(Exception exception, string message, params object[] args) { LogException(Level.Debug, message, args, exception); }

        public void InfoException(Exception exception, string message) { LogException(Level.Info, message, null, exception); }
        public void InfoException(Exception exception, string message, params object[] args) { LogException(Level.Info, message, args, exception); }

        public void WarnException(Exception exception, string message) { LogException(Level.Warn, message, null, exception); }
        public void WarnException(Exception exception, string message, params object[] args) { LogException(Level.Warn, message, args, exception); }

        public void ErrorException(Exception exception, string message) { LogException(Level.Error, message, null, exception); }
        public void ErrorException(Exception exception, string message, params object[] args) { LogException(Level.Error, message, args, exception); }

        public void FatalException(Exception exception, string message) { LogException(Level.Fatal, message, null, exception); }
        public void FatalException(Exception exception, string message, params object[] args) { LogException(Level.Fatal, message, args, exception); }

        public void LogIncoming(Google.ProtocolBuffers.IMessage msg) { Log(Level.Incoming, msg.AsText(), null); }
        public void LogOutgoing(Google.ProtocolBuffers.IMessage msg) { Log(Level.Outgoing, msg.AsText(), null); }
        public void LogIncoming(GameMessage msg) { Log(Level.Incoming, msg.AsText(), null); }
        public void LogOutgoing(GameMessage msg) { Log(Level.Outgoing, msg.AsText(), null); }
    }

    public class Target
    {
        public Level MinimumLevel { get; protected set; }
        public virtual void LogMessage(Level level, string logger, string message) { throw new NotSupportedException(); }
        public virtual void LogException(Level level, string logger, string message, Exception exception) { throw new NotSupportedException(); }
    }

    public class FileTarget : Target, IDisposable
    {
        private readonly string _filePath;

        private FileStream _fileStream;
        private StreamWriter _logStream;

        public FileTarget(Level minLevel, string filePath)
        {
            MinimumLevel = minLevel;
            _filePath = filePath;
            this._fileStream = new FileStream(_filePath, FileMode.Append, FileAccess.Write);
            this._logStream = new StreamWriter(this._fileStream);
            this._logStream.AutoFlush = true;
        }

        public override void LogMessage(Level level, string logger, string message)
        {
            this._logStream.WriteLine(string.Format("[{0}] [{1}]: {2}", level.ToString().PadLeft(5), logger, message));
        }

        public override void LogException(Level level, string logger, string message, Exception exception)
        {
            this._logStream.WriteLine(string.Format("[{0}] [{1}]: {2} - [Exception] {3}", level.ToString().PadLeft(5), logger, message, exception));
        }

        #region de-ctor

        // IDisposable pattern: http://msdn.microsoft.com/en-us/library/fs2xkftw%28VS.80%29.aspx

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Take object out the finalization queue to prevent finalization code for it from executing a second time.
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed) return; // if already disposed, just return

            if (disposing) // only dispose managed resources if we're called from directly or in-directly from user code.
            {
                this._logStream.Close();
                this._logStream.Dispose();
                this._fileStream.Close();
                this._fileStream.Dispose();
            }

            this._logStream = null;
            this._fileStream = null;

            _disposed = true;
        }

        ~FileTarget() { Dispose(false); } // finalizer called by the runtime. we should only dispose unmanaged objects and should NOT reference managed ones.

        #endregion
    }

    public class ConsoleTarget : Target
    {
        // Win32 API constants.
        private const int StdOutputHandle = -11;
        private const int CodePage = 437;

        public ConsoleTarget(Level minLevel, bool initConsole = false)
        {
            MinimumLevel = minLevel;
        }
        
        public override void LogMessage(Level level, string logger, string message)
        {
            SetForeGroundColor(level);
            Console.WriteLine(string.Format("[{0}] [{1}]: {2}", level.ToString().PadLeft(5), logger, message));
        }

        public override void LogException(Level level, string logger, string message, Exception exception)
        {
            SetForeGroundColor(level);
            Console.WriteLine(string.Format("[{0}] [{1}]: {2} - [Exception] {3}", level.ToString().PadLeft(5), logger, message, exception));
        }

        private static void SetForeGroundColor(Level level)
        {
            switch (level)
            {
                case Level.Trace: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case Level.Debug: Console.ForegroundColor = ConsoleColor.Blue; break;
                case Level.Info: Console.ForegroundColor = ConsoleColor.White; break;
                case Level.Warn: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case Level.Error: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case Level.Fatal: Console.ForegroundColor = ConsoleColor.Red; break;
                case Level.Incoming:
                case Level.Outgoing: Console.ForegroundColor = ConsoleColor.White; break;
                default: break;
            }
        }
    }
}
