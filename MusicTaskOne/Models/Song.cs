using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTaskOne.Models
{
    public enum Genre
    {
        Rock = 0,
        Pop = 1,
        Electric
    }

    public class Song
    {
        public Song() { }
        public Song(string name, string performer, Genre genre, uint year, string text)
        {
            Name = name;
            Performer = performer;
            Genre = genre;
            Year = year;
            Text = text;
        }

        public string Name { get; set; }
        public string Performer { get; set; }
        public Genre Genre { get; set; }
        public uint Year { get; set; }
        public string Text { get; set; }
    }
}
