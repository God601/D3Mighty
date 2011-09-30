﻿//Credits To The AllMightyOne's - God601

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using System.Reflection;
using System.Threading;
using D3Sharp.Net.BNet;
using D3Sharp.Net.Game;
using D3Sharp.Utils;
using D3Sharp;

namespace D3Sharp
{

    public partial class Form1 : Form
    {
        private static BnetServer _bnetServer;
        private static GameServer _gameServer;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)//private
        {
            //Progress Bar
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100;
        progressBar1.Value = 0;
            //RichTextBox Console
        richTextBox1.Text += "Copyright (C) 2009-2011 The AllMightyOne's Project - By Karl Fortier-Champagne \n\f";
        richTextBox1.Text += "[D3GS] D3Sharp Revision 4 is loading... \n";
        StartupServers();
        richTextBox1.Text += "[D3GS] D3Sharp Loaded Successfuly! \n\f";
        progressBar1.Value = 100;
        }

        public static void StartupServers()
        {
            Form1 pvpgn = new Form1();
            _bnetServer = new BnetServer();
            _gameServer = new GameServer();

            var bnetServerThread = new Thread(_bnetServer.Run) { IsBackground = true };
            bnetServerThread.Start();
            pvpgn.richTextBox1.Text += "[D3GS] Bnet Server Loaded Successfuly! \n\f";
            pvpgn.progressBar1.Value = 25;

            var gameServerThread = new Thread(_gameServer.Run) { IsBackground = true };
            gameServerThread.Start();
            pvpgn.richTextBox1.Text += "[D3GS] Game Server Loaded Successfuly! \n\f";
            pvpgn.progressBar1.Value = 50;
        }

        public static void StartupD3GS()
        {
            Form1 pvpgn = new Form1();
            _gameServer = new GameServer();

            var gameServerThread = new Thread(_gameServer.Run) { IsBackground = true };
            gameServerThread.Start();
            pvpgn.richTextBox1.Text += "[D3GS] Game Server Loaded Successfuly! \n\f";
            pvpgn.progressBar1.Value = 50;
        }

        public static void StartupBNet()
        {
            Form1 pvpgn = new Form1();
            _gameServer = new GameServer();

            var bnetServerThread = new Thread(_bnetServer.Run) { IsBackground = true };
            bnetServerThread.Start();
            pvpgn.richTextBox1.Text += "[D3GS] Bnet Server Loaded Successfuly! \n\f";
            pvpgn.progressBar1.Value = 50;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.Show();
        }

        public void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void configD3GSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("config.ini");
        }

        private void configMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Assets\\Maps\\universe.txt");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void restartD3GSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "[D3GS] D3GS Is Restarting... \n";
            _gameServer.Shutdown();
            StartupD3GS();
            richTextBox1.Text += "[D3GS] D3GS Restarted Successfuly \n\f";
        }

        private void restartBNetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "[D3GS] BNet Is Restarting... \n";
            _bnetServer.Shutdown();
            StartupBNet();
            richTextBox1.Text += "[D3GS] BNet Restarted Successfuly \n\f";
        }

        //Form2.Show();
    }
}
