using NetMvc.Cms.DAL;

namespace NetMvc.Cms.BL.Interfaces
{
    public interface IBaseService
    {
        NetMvcDbContext GetContext();

        void Dispose();
    }
}