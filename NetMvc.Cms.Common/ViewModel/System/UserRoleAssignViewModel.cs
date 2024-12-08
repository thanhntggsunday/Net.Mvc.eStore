namespace NetMvc.Cms.Common.ViewModel.System
{
    public class UserRoleAssignViewModel : TransactionalInformation
    {
        public string UserIds { get; set; }
        public string RoleNames { get; set; }
    }
}