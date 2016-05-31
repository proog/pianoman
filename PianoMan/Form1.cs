using System;
using System.Windows.Forms;

namespace PianoMan {
	using System.Runtime.InteropServices;
	using System.Threading;

	public partial class Form1 : Form {
		private int _octave;
		private int _interval;
		private int _handle = 3012;

		public Form1() {
			InitializeComponent();
			musicTextbox.KeyUp += MusicTextboxKeyUp;
			midiOutOpen(ref _handle, 0, null, 0, 0);
		}

		private void MusicTextboxKeyUp(object sender, KeyEventArgs e) {
			if(e.KeyData == Keys.Enter)
				PlayButtonClick(musicTextbox, e);
		}

		private void PlayButtonClick(object sender, EventArgs e) {
			_octave = 3;
			_interval = decimal.ToInt32(intervalSelector.Value);
			textBox1.Clear();
			foreach(char c in musicTextbox.Text) {
				switch (c) {
					case '-':
						_octave--;
						if(_octave < -2)
							_octave = -2;
						textBox1.Text += @"-: octave down (base is " + _octave + @")" + Environment.NewLine;
						break;
					case '+':
						_octave++;
						if(_octave > 7)
							_octave = 7;
						textBox1.Text += @"+: octave up (base is " + _octave + @")" + Environment.NewLine;
						break;
					case '>':
						_interval -= 50;
						if(_interval < 0)
							_interval = 0;
						textBox1.Text += @">: interval -50 (" + _interval + @")" + Environment.NewLine;
						break;
					case '<':
						_interval += 50;
						textBox1.Text += @"<: interval +50 (" + _interval + @")" + Environment.NewLine;
						break;
					case ' ':
						textBox1.Text += Environment.NewLine;
						break;
					default:
						var note = NoteTranslator.CharToMidi(c, _octave);
						int midi = 0x00600090 + note.Midi;
						midiOutShortMsg(_handle, midi);
						textBox1.Text += c + @": " + note.NoteDesc + @" " + note.Octave + Environment.NewLine;
						Thread.Sleep(_interval);
						break;
				}
			}
		}

		// Handle midi messages sent from system.
		protected delegate void MidiCallback(int handle, int msg, int instance, int param1, int param2);

		[DllImport("winmm.dll")]
		private static extern int midiOutOpen(ref int handle, int deviceId, MidiCallback proc, int instance, int flags);

		[DllImport("winmm.dll")]
		protected static extern int midiOutShortMsg(int handle, int message);
	}
}
