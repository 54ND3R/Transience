using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transience.Models {
    public class MemoryEvaluation {
        public int Id { get; set; }
        public Memory Exercise { get; set; }
        public string GivenAnswer { get; set; }
        public bool Correct { get; set; }
    }
}