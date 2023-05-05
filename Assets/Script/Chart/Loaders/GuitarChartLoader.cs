﻿using System.Collections.Generic;
using MoonscraperChartEditor.Song;
using YARG.Data;

namespace YARG.Chart {
	public class GuitarChartLoader : IChartLoader<NoteInfo> {
		public List<NoteInfo> GetNotesFromChart(MoonSong song, MoonChart chart) {
			var notes = new List<NoteInfo>();

			foreach (var moonNote in chart.notes) {
				// Length of the note in realtime
				double timeLength = song.TickToTime(moonNote.tick + moonNote.length, song.resolution) - moonNote.time;

				var note = new NoteInfo {
					time = (float)moonNote.time,
					length = (float)timeLength,
					fret = moonNote.rawNote,
					hopo = moonNote.type == MoonNote.MoonNoteType.Hopo,
					tap = moonNote.type == MoonNote.MoonNoteType.Tap,
				};

				notes.Add(note);
			}

			return notes;
		}
	}
}