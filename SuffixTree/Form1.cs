using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuffixTree
{
    public partial class Form1 : Form
    {
        SuffixTree suffix_Tree = new SuffixTree();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            suffix_Tree.Add(Convert.ToChar(textBox1.Text));
        }
    }
}
