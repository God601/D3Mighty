using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Reflection;
using System.Threading;
//using D3Sharp.Net.BNet;
//using D3Sharp.Net.Game;
//using D3Sharp.Utils;
using D3Sharp;

namespace D3Sharp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100;
        progressBar1.Value = 100;

        richTextBox1.Text += "[D3GS] D3Sharp Revision 4 is loading...";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        //Form2.Show();
    }
}
