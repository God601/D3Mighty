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

using Mooege.Common;
using Mooege.Net.GS;
using Mooege.Net.MooNet;
using Mooege;

namespace D3Mighty
{
    public partial class FormMusic : Form
    {
        public FormMusic()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void MediaLoad()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Mp3 Files|*.mp3|All Files|*.*";
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
        }

        public void MediaStop()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        public sealed class Config : Mooege.Common.Config.Config
        {
            public string Music { get { return this.GetString("Music", @"C:\Users\TheExecutioner\D3Mighty\source\D3Sharp\bin\Release\Assets\mediafile.mp3"); } set { this.Set("Music", value); } }

            private static readonly Config _instance = new Config();
            public static Config Instance { get { return _instance; } }
            private Config() : base("Core") { }
        }
    }
}
