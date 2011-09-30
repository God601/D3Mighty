/*
 * Copyright (C) 2011 D3Sharp Project
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
using System.Reflection;
using System.Threading;
using D3Sharp.Net.BNet;
using D3Sharp.Net.Game;
using D3Sharp.Utils;

using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; 


namespace D3Sharp
{
    internal class Program
        
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        private static BnetServer _bnetServer;
        private static GameServer _gameServer;
        int i = 1;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 pvpgn = new Form1();

            //pvpgn.textBox1.Text = "Loading D3GS...";

            // Watch for unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            // Don't forget this..
            LogManager.Enabled = true;
            LogManager.AttachLogTarget(new ConsoleTarget(Level.Trace));
            LogManager.AttachLogTarget(new FileTarget(Level.Trace, "d3sharp-log.txt"));

            //MultiThreading Method
            //Form3 mainForm = new Form3();
            for (int i = 0; i < 1; i++)//(int i = 0; i < 5; i++)
            {
                Thread backgroundThread = new Thread(new ThreadStart(pvpgn.doSomething));
                backgroundThread.Start();
                //mainForm.Show();
            }

            //

            PrintBanner();
            PrintLicense();

            Logger.Info("D3Sharp Revision 4 is loading...", Assembly.GetExecutingAssembly().GetName().Version);
            StartupForm();
            //StartupServers();
            
        }

        public static void StartupForm()
        {
            Application.EnableVisualStyles();
            Form1 pvpgn = new Form1();
            //System.Threading.Thread.Sleep(999999); 
            Application.Run(new Form1());

        }

        public static void StartupServers()//private
        {
            //Form1 pvpgn = new Form1();
            _bnetServer = new BnetServer();
            _gameServer = new GameServer();

            var bnetServerThread = new Thread(_bnetServer.Run) { IsBackground = true };
            bnetServerThread.Start();

            var gameServerThread = new Thread(_gameServer.Run) { IsBackground = true };
            gameServerThread.Start();
            //pvpgn.Show();
            //Application.Run(pvpgn);
            //Logger.Info("Form1.cs loaded.");
            //pvpgn.textBox1.Text = "Loading D3GS...";

            // Read user input indefinitely
            // TODO: Replace with proper command parsing and execution

            while (true)
            {
                var line = Console.ReadLine();
                if (!string.Equals("quit", line, StringComparison.OrdinalIgnoreCase)
                 && !string.Equals("exit", line, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                Logger.Info("Shutting down servers...");
                _bnetServer.Shutdown();
                _gameServer.Shutdown();
                break;
            }
        }

        private static void PrintBanner()
        {
            Console.WriteLine(@"    ____    __    ___      ___   ___    ");
            Console.WriteLine(@"   /    \  |  |  |   \    /     /   \  | ");
            Console.WriteLine(@"   |      |____| |____\  /____  |   |  | ");
            Console.WriteLine(@"   |  ___ |    | |    /  \    \ |   |  | ");
            Console.WriteLine(@"   \____/  |__|  |___/    \___/ \___/  | ");
            Console.WriteLine(@"");
            Console.WriteLine();
        }

        private static void PrintLicense()
        {
            Console.WriteLine("Copyright (C) 2009-2011 The AllMightyOne's Project");
            Console.WriteLine();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
                Logger.FatalException((e.ExceptionObject as Exception), "Application terminating because of unhandled exception.");
            else
                Logger.ErrorException((e.ExceptionObject as Exception), "Caught unhandled exception.");
            Console.ReadLine();
        }
    }
}
