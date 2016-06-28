using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Transience.Models.DAL.Interfaces;

namespace Transience.Models.DAL.Repositories {
    public class MemoryRepository : IMemoryRepository, IDisposable {
        private TransienceDbContext context;

        public MemoryRepository(TransienceDbContext context) {
            this.context = context;
        }

        public IEnumerable<Memory> Get() {
            return context.Memories.ToList();
        }

        public Memory GetById(int id) {
            return context.Memories.Find(id);
        }

        public void Delete(int id) {
            Memory deletedMemory = GetById(id);
            context.Memories.Remove(deletedMemory);
        }

        public void Update(Memory modifiedMemory) {
            context.Entry(modifiedMemory).State = EntityState.Modified;
        }

        public void Insert(Memory newMemory) {
            context.Memories.Add(newMemory);
        }

        public void Save() {
            context.SaveChanges();
        }

        

        //IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}