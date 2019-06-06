using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mklinkGUI
{
    public partial class Form1 : Form
    {
        private Controller controller;
        private List<string> ItemList = new List<string>();
        public Form1(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;
            this.Text = "vSymLinks - A windows GUI version of Symbolic Links";
            this.listBox1.HorizontalScrollbar = true;

            hintLabel.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
                if(controller.isFile(item.ToString()))
                    controller.linkFile(item.ToString());
                else
                    controller.linkDir(item.ToString());

        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ListBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                if (!ItemList.Contains(s[i]))
                {
                    ItemList.Add(s[i]);
                    listBox1.Items.Add(s[i]);
                    if (hintLabel.Visible)
                        hintLabel.Visible = !hintLabel.Visible;
                }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ItemList.Clear();

            hintLabel.Visible = true;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            if(listBox1.Items.Count == 0)
                hintLabel.Visible = true;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form2 = new AboutForm();
            form2.Show();
        }
    }
}
