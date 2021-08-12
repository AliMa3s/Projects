using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace VoiceCommandV2._0
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        SpeechSynthesizer sS = new SpeechSynthesizer();
        SpeechRecognitionEngine sL = new SpeechRecognitionEngine();
        Random rand = new Random();
        int RecTimeOut = 0;
        DateTime dt = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sr.SetInputToDefaultAudioDevice(); //Default audio source
            sr.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            sr.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(sr_SpeechRecognized);
            sr.RecognizeAsync(RecognizeMode.Multiple);

            sL.SetInputToDefaultAudioDevice();
            sL.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            sL.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sL_SpeechRecognized);
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            if(speech == "Hello") {
                sS.SpeakAsync("Hi sir, how can i help you");
            }
            if (speech == "how are you") {
                sS.SpeakAsync("Im fine how about you, sir");
            }
            if (speech == "What time is it") {
                sS.SpeakAsync(DateTime.Now.ToString("h mm ss tt"));
            }
            if(speech == "stop talking") {
                sS.SpeakAsyncCancelAll();
                ranNum = rand.Next(1,2);
                if(ranNum == 1) {
                    sS.SpeakAsync("Yes sir");
                }
                if (ranNum == 2) {
                    sS.SpeakAsync("I am sorry, i will be quiet");
                }
            }

            if(speech == "stop listening") {
                sS.SpeakAsync("if you need just ask");
                sr.RecognizeAsyncCancel();
                sL.RecognizeAsync(RecognizeMode.Multiple);
            }
            if(speech == "show commands") {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                lstCommands.Items.Clear();
                lstCommands.SelectionMode = SelectionMode.None;
                lstCommands.Visible = true;
                foreach (String command in commands) {
                    lstCommands.Items.Add(command);
                }
            }
            if(speech == "hide commands") {
                lstCommands.Visible = false;
            }
        }
        private void sr_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }
        private void sL_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if(speech == "hey hey") {
                sL.RecognizeAsyncCancel();
                sS.SpeakAsync("Yes Sir");
                sr.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void TmrSpeaking_Tick(object sender, EventArgs e)
        {
            if(RecTimeOut == 10) {
                sr.RecognizeAsyncCancel();
            }else if (RecTimeOut == 11) {
                TmrSpeaking.Stop();
                sL.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }
    }
}
