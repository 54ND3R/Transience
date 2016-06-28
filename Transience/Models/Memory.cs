using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transience.Models {
    public class Memory {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }
    }
}