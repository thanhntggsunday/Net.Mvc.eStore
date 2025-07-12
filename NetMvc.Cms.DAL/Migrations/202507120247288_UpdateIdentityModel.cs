namespace NetMvc.Cms.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentityModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AppUserClaims");
            DropPrimaryKey("dbo.AppUserLogins");
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AppUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AppUserClaims", "Id");
            AddPrimaryKey("dbo.AppUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AppUserLogins");
            DropPrimaryKey("dbo.AppUserClaims");
            AlterColumn("dbo.AppUserLogins", "ProviderKey", c => c.String());
            AlterColumn("dbo.AppUserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AppUserLogins", "UserId");
            AddPrimaryKey("dbo.AppUserClaims", "UserId");
        }
    }
}
