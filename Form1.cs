﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.Speech;
using System.Speech.Synthesis;

namespace PDF_to_Text
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechsynth = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files(*.pdf)|*.pdf";
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                String path = ofd.FileName.ToString();
                textBox1.Text = path;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PDDocument doc = PDDocument.load(textBox1.Text);
            PDFTextStripper striper = new PDFTextStripper();
            richTextBox1.Text = (striper.getText(doc));
            speechsynth.SelectVoiceByHints(VoiceGender.Female);
            speechsynth.SpeakAsync(""+richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.Filter = "RTF File|*.rtf";
            if (saveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length>0)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
