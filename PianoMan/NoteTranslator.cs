namespace PianoMan {
	public struct Note {
		public readonly int Midi;
		public readonly string NoteDesc;
		public readonly int Octave;

		public Note(int midi, string noteDesc, int octave) {
			Midi = midi;
			NoteDesc = noteDesc;
			Octave = octave;
		}
	}

	class NoteTranslator {
		// http://www.somascape.org/midi/help/notes.html
		public static Note CharToMidi(char c, int octave) {
			int o = 0xC00 * octave; // 0xC00 = space between the same note in different octaves
			switch(c) {
				case 'q':
					return new Note(0x1800 + o, "C", octave);
				case 'w':
					return new Note(0x1900 + o, "C#/Db", octave);
				case 'e':
					return new Note(0x1A00 + o, "D", octave);
				case 'r':
					return new Note(0x1B00 + o, "D#/Eb", octave);
				case 't':
					return new Note(0x1C00 + o, "E", octave);
				case 'y':
					return new Note(0x1D00 + o, "F", octave);
				case 'u':
					return new Note(0x1E00 + o, "F#/Gb", octave);
				case 'i':
					return new Note(0x1F00 + o, "G", octave);
				case 'o':
					return new Note(0x2000 + o, "G#/Ab", octave);
				case 'p':
					return new Note(0x2100 + o, "A", octave);
				case 'a':
					return new Note(0x2200 + o, "A#/Bb", octave);
				case 's':
					return new Note(0x2300 + o, "B", octave);
				case 'd':
					return new Note(0x2400 + o, "C", octave + 1);
				case 'f':
					return new Note(0x2500 + o, "C#/Db", octave + 1);
				case 'g':
					return new Note(0x2600 + o, "D", octave + 1);
				case 'h':
					return new Note(0x2700 + o, "D#/Eb", octave + 1);
				case 'j':
					return new Note(0x2800 + o, "E", octave + 1);
				case 'k':
					return new Note(0x2900 + o, "F", octave + 1);
				case 'l':
					return new Note(0x2A00 + o, "F#/Gb", octave + 1);
				case 'z':
					return new Note(0x2B00 + o, "G", octave + 1);
				case 'x':
					return new Note(0x2C00 + o, "G#/Ab", octave + 1);
				case 'c':
					return new Note(0x2D00 + o, "A", octave + 1);
				case 'v':
					return new Note(0x2E00 + o, "A#/Bb", octave + 1);
				case 'b':
					return new Note(0x2F00 + o, "B", octave + 1);
				case 'n':
					return new Note(0x3000 + o, "C", octave + 2);
				case 'm':
					return new Note(0x3100 + o, "C#/Db", octave + 2);
				default:
					return new Note(0, "undefined", octave);
			}
		}
	}
}
