using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.DAL;

namespace NetMvc.Cms.BL.ServiceImp
{
   
    public class BaseService : IBaseService
    {
        private NetMvcDbContext _context;

        public NetMvcDbContext GetContext()
        {
            if (_context == null)
            {
                _context = new NetMvcDbContext();
            }

            return _context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
