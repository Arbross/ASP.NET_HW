using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_2_TODO_List
{
    public enum Status
    {
        AWAITING = 0,
        WORKING = 1,
        FINISHED = 2,
        RETURNED = 3
    }

    public class TODO
    {
        public TODO() { Status = Status.AWAITING; }
        public TODO(string id, string header, string username, string doing, DateTime finishDate, Status status)
        {
            Id = id;
            Header = header;
            Username = username;
            Doing = doing;
            FinishDate = finishDate;
            Status = status;
        }

        [Required(ErrorMessage = "You must enter a id.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "You must enter a header.")]
        public string Header { get; set; }
        [MinLength(3, ErrorMessage = "You must enter more than 3 symbols."), Required(ErrorMessage = "You must enter a username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You must enter a doing task.")]
        public string Doing { get; set; }
        [DisplayName("Finish Date"), Required(ErrorMessage = "You must enter a date.")]
        public DateTime FinishDate { get; set; }
        public Status Status { get; set; }

        public int? TypeId { get; set; }
        public virtual Type Type { get; set; }
    }
}
