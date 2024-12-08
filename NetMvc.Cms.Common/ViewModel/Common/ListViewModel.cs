using System.Collections.Generic;

namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class ListViewModel<T>
    {
        public ListViewModel()
        {
            Transactional = new TransactionalInformation();
        }

        public TransactionalInformation Transactional { get; set; }
        public IList<T> Data { get; set; }
    }
}