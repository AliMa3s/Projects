using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Diagnostics;

namespace VoiceCommand
{
    public partial class VoiceCommand : Form
    {
        public VoiceCommand()
        {
            InitializeComponent();
        }
        SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        PromptBuilder pb = new PromptBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.SelectVoiceByHints(VoiceGender.Female);
            Choices list = new Choices();
            list.Add(File.ReadAllLines(@"C:\Users\alima\source\repos\VoiceCommand\Commands\commands.txt"));

            Grammar gm = new Grammar(new GrammarBuilder(list));
            try {
                sr.RequestRecognizerUpdate();
                sr.LoadGrammar(gm);
                sr.SpeechRecognized += Sr_SpeechRecongnized;
                sr.SetInputToDefaultAudioDevice();
                sr.RecognizeAsync(RecognizeMode.Multiple);

            } catch (Exception) {

                throw;
            }
            pb.ClearContent();
            pb.AppendText(richTextBox1.Text);
            s.Speak(pb);
        }
        private bool wake = false;
        public void Say(string phrase)
        {
            s.SpeakAsync(phrase);
            wake = false;

        }
        private void Sr_SpeechRecongnized(object sender, SpeechRecognizedEventArgs e)
        {
            string spSaid = e.Result.Text;
            if (spSaid == "hey bot") {
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"");
                //player.Play();
                wake = true;
            }
            if (wake) {


                switch (spSaid) {
                    case ("hello"):
                    Say("hi boss");
                    break;
                    case ("how are you doing"):
                    Say("good sir, how about you");
                    break;
                    case ("open google"):
                    Say("opening google");
                    Process.Start("https://www.google.com");
                    break;

                    case ("open mozila"):
                    Say("opening mozila firefox");
                    Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe");
                    break;

                    case ("open youtube"):
                    Say("opening youtube");
                    Process.Start(@"https://www.youtube.com");
                    break;

                    case ("close"):
                    Say("closing program");
                    SendKeys.Send("%{F4}");
                    break;

                    case ("exit"):
                    s.Speak("closing down sir, thank you for using anna ai");
                    Application.Exit();
                    break;
                }
            }
        }
    }
}
