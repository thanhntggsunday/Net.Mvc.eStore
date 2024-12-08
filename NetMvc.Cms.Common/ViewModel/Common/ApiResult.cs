namespace NetMvc.Cms.Common.ViewModel.Common
{
    public class ApiResult<T> : TransactionalInformation
    {
        public ApiResult()
        {
            
        }

        public ApiResult(T data)
        {
            ResultObj = data;
        }

        public T ResultObj { get; set; }
    }
}