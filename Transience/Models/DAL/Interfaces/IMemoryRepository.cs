using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transience.Models.DAL.Interfaces {
    public interface IMemoryRepository : IDisposable {
        IEnumerable<Memory> Get();
        Memory GetById(int id);
        void Insert(Memory newMemory);
        void Delete(int id);
        void Update(Memory modifiedMemory);
        void Safe();
    }
}
