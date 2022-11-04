using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Edit
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.Enabled = (richTextBox1.SelectedText.Length >0)? true : false;
            cutToolStripMenuItem.Enabled = (richTextBox1.SelectedText.Length > 0) ? true : false;
            pasteToolStripMenuItem.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
        }

        private void editToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            pasteToolStripMenuItem.Enabled = true;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            pasteToolStripMenuItem.Enabled = true;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                richTextBox1.Paste();
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Format
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        //lưu file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Filter = "Text file|*.txt|PDF file|*.pdf|";
            saveFileDialog1.Filter = "Plain text (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }
    }
}
