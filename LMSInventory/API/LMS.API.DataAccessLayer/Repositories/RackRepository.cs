using LMS.API.DataAccessLayer.Interfaces;
using LMS.API.DataAccessLayer.Models;


namespace LMS.API.DataAccessLayer.Repositories
{
    public class RackRepository : GenericDataRepository<Rack>, IRackRepository
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        ~RackRepository()
        {
            Dispose(false);
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
