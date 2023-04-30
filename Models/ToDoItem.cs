using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string ?Description { get; set; }
        public bool IsComplete { get; set; }

    }

    public class GetItem
    {
        public int Id { get; set; }
    }
}
