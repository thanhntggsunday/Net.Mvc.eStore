namespace NetMvc.Cms.Common
{
    public enum AccessLevel
    {
        Create,
        Edit,
        Delete,
        List,
        Full = (Create | Edit | Delete | List)
    }
}
