﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NMeCab;

namespace MecabViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            richTextBox.SuspendLayout();
            richTextBox.Clear();
            MeCabTagger meCabTagger = MeCabTagger.Create();
            MeCabNode node = meCabTagger.ParseToNode(textBoxArea.Text);
            while (node != null)
            {
                if (node.CharType > 0)
                {
                    if (node.Feature.Contains("固有名詞"))
                    {
                        richTextBox.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        richTextBox.SelectionBackColor = Color.Transparent;
                    }

                    richTextBox.SelectedText = node.Surface;
                }
                node = node.Next;
            }
            richTextBox.ResumeLayout();
            
        }
    }
}