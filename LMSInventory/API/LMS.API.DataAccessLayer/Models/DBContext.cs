using Microsoft.EntityFrameworkCore;

using LMS.API.Utils;

namespace LMS.API.DataAccessLayer.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.DatabaseUtils.SQL_CONNECTION_STRING);
        }


        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Rack> Rack { get; set; }
        public virtual DbSet<Element> Element { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        ~DBContext()
        {
            Dispose(false);
        }

        public new void Dispose()
        {
            Dispose(true);
        }


        #endregion

    }
}