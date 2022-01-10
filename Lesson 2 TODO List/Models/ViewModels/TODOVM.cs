using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_2_TODO_List
{
    public class TODOVM
    {
        public TODO TODO { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
    }
}
