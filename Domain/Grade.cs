using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grade
    {
        public int GardeId { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
