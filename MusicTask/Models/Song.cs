using MusicTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTask
{
    public class Song
    {
        public Song() { Id = 0; }
        public Song(int id, string name, string performer, uint year, string text)
        {
            Id = id;
            Name = name;
            Performer = performer;
            Year = year;
            Text = text;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter a performer.")]
        public string Performer { get; set; }
        [Required(ErrorMessage = "You must enter a year.")]
        public uint Year { get; set; }
        [Required(ErrorMessage = "You must enter a text.")]
        public string Text { get; set; }

        [DisplayName("Genre"), Required(ErrorMessage = "You must enter a genre.")]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
