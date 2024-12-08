using PagedList;

namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class PagedListViewModel<T>
    {
        public PagedListViewModel()
        {
            Transactional = new TransactionalInformation();
        }

        public TransactionalInformation Transactional { get; set; }
        public IPagedList<T> Data { get; set; }
    }
}