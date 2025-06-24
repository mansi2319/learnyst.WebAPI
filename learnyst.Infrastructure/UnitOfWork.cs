using learnyst.Core.Entities;
using learnyst.Infrastructure.Data;
using learnyst.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnyst.Infrastructure
{
    public class UnitOfWork(AppDbContext context) : IDisposable
    {
        private readonly AppDbContext _context = context;

        //private AppDbContext context = new AppDbContext();
        private GenericRepository<user> userRepository;
        private GenericRepository<course> courseRepository;

        public GenericRepository<user> DepartmentRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<user>(_context);
                }
                return userRepository;
            }
        }

        public GenericRepository<course> CourseRepository
        {
            get
            {

                if (this.CourseRepository == null)
                {
                    this.courseRepository = new GenericRepository<course>(_context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
