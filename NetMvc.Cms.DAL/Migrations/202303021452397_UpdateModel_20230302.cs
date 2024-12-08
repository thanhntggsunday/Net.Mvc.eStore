namespace NetMvc.Cms.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel_20230302 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "StrStatus", c => c.String());
            AddColumn("dbo.Action", "StrStatus", c => c.String());
            AddColumn("dbo.Function_Action", "StrStatus", c => c.String());
            AddColumn("dbo.Functions", "StrStatus", c => c.String());
            AddColumn("dbo.Role_Permission", "StrStatus", c => c.String());
            AddColumn("dbo.Albums", "StrStatus", c => c.String());
            AddColumn("dbo.CartItems", "StrStatus", c => c.String());
            AddColumn("dbo.Categories", "StrStatus", c => c.String());
            AddColumn("dbo.Contacts", "StrStatus", c => c.String());
            AddColumn("dbo.Feedbacks", "StrStatus", c => c.String());
            AddColumn("dbo.Footers", "StrStatus", c => c.String());
            AddColumn("dbo.GroupSlides", "StrStatus", c => c.String());
            AddColumn("dbo.Languages", "StrStatus", c => c.String());
            AddColumn("dbo.Menus", "StrStatus", c => c.String());
            AddColumn("dbo.MenuTypes", "StrStatus", c => c.String());
            AddColumn("dbo.Newses", "StrStatus", c => c.String());
            AddColumn("dbo.NewsTags", "StrStatus", c => c.String());
            AddColumn("dbo.OrderDetails", "StrStatus", c => c.String());
            AddColumn("dbo.Orders", "StrStatus", c => c.String());
            AddColumn("dbo.Permissions", "StrStatus", c => c.String());
            AddColumn("dbo.Photos", "StrStatus", c => c.String());
            AddColumn("dbo.ProductCategories", "StrStatus", c => c.String());
            AddColumn("dbo.Products", "StrStatus", c => c.String());
            AddColumn("dbo.Slides", "StrStatus", c => c.String());
            AddColumn("dbo.SystemConfigs", "StrStatus", c => c.String());
            AddColumn("dbo.Tags", "StrStatus", c => c.String());
            AddColumn("dbo.UserActivityLogs", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.UserActivityLogs", "CreatedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.UserActivityLogs", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserActivityLogs", "ModifiedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.UserActivityLogs", "StrStatus", c => c.String());
            AddColumn("dbo.UserActivityLogs", "Status", c => c.Boolean());
            AddColumn("dbo.UserActivityLogs", "LanguageCode", c => c.String(maxLength: 10));
            DropColumn("dbo.Abouts", "IsActive");
            DropColumn("dbo.Action", "IsActive");
            DropColumn("dbo.Function_Action", "IsActive");
            DropColumn("dbo.Functions", "IsActive");
            DropColumn("dbo.Role_Permission", "IsActive");
            DropColumn("dbo.Albums", "IsActive");
            DropColumn("dbo.CartItems", "IsActive");
            DropColumn("dbo.Categories", "IsActive");
            DropColumn("dbo.Contacts", "IsActive");
            DropColumn("dbo.Feedbacks", "IsActive");
            DropColumn("dbo.Footers", "IsActive");
            DropColumn("dbo.GroupSlides", "IsActive");
            DropColumn("dbo.Languages", "IsActive");
            DropColumn("dbo.Menus", "IsActive");
            DropColumn("dbo.MenuTypes", "IsActive");
            DropColumn("dbo.Newses", "IsActive");
            DropColumn("dbo.NewsTags", "IsActive");
            DropColumn("dbo.OrderDetails", "IsActive");
            DropColumn("dbo.Orders", "IsActive");
            DropColumn("dbo.Permissions", "IsActive");
            DropColumn("dbo.Photos", "IsActive");
            DropColumn("dbo.ProductCategories", "IsActive");
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Slides", "IsActive");
            DropColumn("dbo.SystemConfigs", "IsActive");
            DropColumn("dbo.Tags", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "IsActive", c => c.String());
            AddColumn("dbo.SystemConfigs", "IsActive", c => c.String());
            AddColumn("dbo.Slides", "IsActive", c => c.String());
            AddColumn("dbo.Products", "IsActive", c => c.String());
            AddColumn("dbo.ProductCategories", "IsActive", c => c.String());
            AddColumn("dbo.Photos", "IsActive", c => c.String());
            AddColumn("dbo.Permissions", "IsActive", c => c.String());
            AddColumn("dbo.Orders", "IsActive", c => c.String());
            AddColumn("dbo.OrderDetails", "IsActive", c => c.String());
            AddColumn("dbo.NewsTags", "IsActive", c => c.String());
            AddColumn("dbo.Newses", "IsActive", c => c.String());
            AddColumn("dbo.MenuTypes", "IsActive", c => c.String());
            AddColumn("dbo.Menus", "IsActive", c => c.String());
            AddColumn("dbo.Languages", "IsActive", c => c.String());
            AddColumn("dbo.GroupSlides", "IsActive", c => c.String());
            AddColumn("dbo.Footers", "IsActive", c => c.String());
            AddColumn("dbo.Feedbacks", "IsActive", c => c.String());
            AddColumn("dbo.Contacts", "IsActive", c => c.String());
            AddColumn("dbo.Categories", "IsActive", c => c.String());
            AddColumn("dbo.CartItems", "IsActive", c => c.String());
            AddColumn("dbo.Albums", "IsActive", c => c.String());
            AddColumn("dbo.Role_Permission", "IsActive", c => c.String());
            AddColumn("dbo.Functions", "IsActive", c => c.String());
            AddColumn("dbo.Function_Action", "IsActive", c => c.String());
            AddColumn("dbo.Action", "IsActive", c => c.String());
            AddColumn("dbo.Abouts", "IsActive", c => c.String());
            DropColumn("dbo.UserActivityLogs", "LanguageCode");
            DropColumn("dbo.UserActivityLogs", "Status");
            DropColumn("dbo.UserActivityLogs", "StrStatus");
            DropColumn("dbo.UserActivityLogs", "ModifiedBy");
            DropColumn("dbo.UserActivityLogs", "ModifiedDate");
            DropColumn("dbo.UserActivityLogs", "CreatedBy");
            DropColumn("dbo.UserActivityLogs", "CreatedDate");
            DropColumn("dbo.Tags", "StrStatus");
            DropColumn("dbo.SystemConfigs", "StrStatus");
            DropColumn("dbo.Slides", "StrStatus");
            DropColumn("dbo.Products", "StrStatus");
            DropColumn("dbo.ProductCategories", "StrStatus");
            DropColumn("dbo.Photos", "StrStatus");
            DropColumn("dbo.Permissions", "StrStatus");
            DropColumn("dbo.Orders", "StrStatus");
            DropColumn("dbo.OrderDetails", "StrStatus");
            DropColumn("dbo.NewsTags", "StrStatus");
            DropColumn("dbo.Newses", "StrStatus");
            DropColumn("dbo.MenuTypes", "StrStatus");
            DropColumn("dbo.Menus", "StrStatus");
            DropColumn("dbo.Languages", "StrStatus");
            DropColumn("dbo.GroupSlides", "StrStatus");
            DropColumn("dbo.Footers", "StrStatus");
            DropColumn("dbo.Feedbacks", "StrStatus");
            DropColumn("dbo.Contacts", "StrStatus");
            DropColumn("dbo.Categories", "StrStatus");
            DropColumn("dbo.CartItems", "StrStatus");
            DropColumn("dbo.Albums", "StrStatus");
            DropColumn("dbo.Role_Permission", "StrStatus");
            DropColumn("dbo.Functions", "StrStatus");
            DropColumn("dbo.Function_Action", "StrStatus");
            DropColumn("dbo.Action", "StrStatus");
            DropColumn("dbo.Abouts", "StrStatus");
        }
    }
}
