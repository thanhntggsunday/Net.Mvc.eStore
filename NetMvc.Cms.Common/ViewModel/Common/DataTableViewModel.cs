using System.Collections.Generic;

namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class DataTableViewModel<T>
    {
        public DataTableViewModel()
        {
            returnMessage = new List<string>();
        }

        public int draw { get; set; }
        public string error { get; set; }
        public long recordsFiltered { get; set; }
        public long recordsTotal { get; set; }
        public T[] data { get; set; }

        public bool returnStatus { get; set; }
        public List<string> returnMessage { get; set; }
        public int pagesTotal { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string searchString { get; set; }
        public string url { get; set; }
        
    }
}