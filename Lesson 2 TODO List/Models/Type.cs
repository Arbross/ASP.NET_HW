using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_2_TODO_List
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<TODO> TODOs { get; set; }
    }
}
