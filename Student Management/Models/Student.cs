using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public StudentType type { get; set; }
        public Gender Gender { get; set; }

    }
}
