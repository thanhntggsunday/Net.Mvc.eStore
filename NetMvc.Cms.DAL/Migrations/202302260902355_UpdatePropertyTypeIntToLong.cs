namespace NetMvc.Cms.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePropertyTypeIntToLong : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderDetails", "Quantitty", c => c.Long(nullable: false));
            AlterColumn("dbo.Orders", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderID", "ProductID" });
            AddPrimaryKey("dbo.Orders", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AlterColumn("dbo.Orders", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "Quantitty", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "ID");
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderID", "ProductID" });
        }
    }
}
