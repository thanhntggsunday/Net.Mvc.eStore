namespace NetMvc.Cms.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactTblUpdated : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contacts", "Title", c => c.String(maxLength: 250));
            AddPrimaryKey("dbo.Contacts", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Contacts", "ID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.Contacts", new[] { "ID", "Title" });
        }
    }
}
