using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transience.Models {
    public class Test {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Memory> Memories { get; set; }
    }
}