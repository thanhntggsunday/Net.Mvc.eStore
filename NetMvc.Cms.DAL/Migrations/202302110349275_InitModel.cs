namespace NetMvc.Cms.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250),
                        ContentHtml = c.String(storeType: "ntext"),
                        Images = c.String(maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 10, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 10, unicode: false),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Function_Action",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActionId = c.String(nullable: false, maxLength: 100),
                        FunctionId = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Action", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.Functions", t => t.FunctionId, cascadeDelete: true)
                .Index(t => t.ActionId)
                .Index(t => t.FunctionId);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 250),
                        Link = c.String(nullable: false, maxLength: 250),
                        Target = c.String(nullable: false, maxLength: 10, unicode: false),
                        Order = c.Int(nullable: false),
                        CssClass = c.String(maxLength: 50, unicode: false),
                        IsLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ParentID = c.String(maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role_Permission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Function_ActionID = c.Int(nullable: false),
                        AppRoleId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppRoles", t => t.AppRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Function_Action", t => t.Function_ActionID, cascadeDelete: true)
                .Index(t => t.Function_ActionID)
                .Index(t => t.AppRoleId);
            
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Images = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        Order = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 20, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Boolean(),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Images = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        Order = c.Int(),
                        ParentID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Boolean(),
                        IsIntroduced = c.Boolean(),
                        LanguageCode = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        ContentHtml = c.String(storeType: "ntext"),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Title, t.Status });
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Company = c.String(maxLength: 100),
                        Address = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        IsReaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ContentHtml = c.String(storeType: "ntext"),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupSlides",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        IsActived = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        IsActived = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 250),
                        Link = c.String(nullable: false, maxLength: 250),
                        Target = c.String(nullable: false, maxLength: 10, unicode: false),
                        Order = c.Int(nullable: false),
                        CssClass = c.String(maxLength: 50, unicode: false),
                        IsLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        GroupID = c.String(nullable: false, maxLength: 50, unicode: false),
                        ParentID = c.String(maxLength: 50, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        Language = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuTypes",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        IsActived = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Newses",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250),
                        ContentHtml = c.String(storeType: "ntext"),
                        Images = c.String(maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 10, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 10, unicode: false),
                        PublishedDate = c.DateTime(),
                        RelatedNewses = c.String(maxLength: 50, unicode: false),
                        CategoryID = c.Long(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Source = c.String(maxLength: 50),
                        UpTopNew = c.DateTime(),
                        UpTopHot = c.DateTime(),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewsTags",
                c => new
                    {
                        NewsID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.NewsID, t.TagID });
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.String(nullable: false, maxLength: 20, unicode: false),
                        RoleID = c.String(nullable: false, maxLength: 50, unicode: false),
                        FunctionID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Images = c.String(maxLength: 250),
                        AlbumID = c.Long(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Images = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        Order = c.Int(),
                        ParentID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Boolean(),
                        LanguageCode = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Code = c.String(maxLength: 50, unicode: false),
                        MetaTitle = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250),
                        Images = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 0),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 10, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 10, unicode: false),
                        CategoryID = c.Long(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Source = c.String(maxLength: 50),
                        UpTopNew = c.DateTime(),
                        UpTopHot = c.DateTime(),
                        Detail = c.String(storeType: "ntext"),
                        LanguageCode = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                        Link = c.String(maxLength: 250),
                        Images = c.String(nullable: false, maxLength: 250),
                        Order = c.Int(nullable: false),
                        GroupID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UniqueKey = c.String(nullable: false, maxLength: 50, unicode: false),
                        Value = c.String(nullable: false, maxLength: 250),
                        Unit = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        IsActived = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserActivityLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActionName = c.String(nullable: false, maxLength: 50),
                        ActionDate = c.DateTime(nullable: false),
                        IPAddress = c.String(nullable: false, maxLength: 50, unicode: false),
                        SessionID = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 20, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 20, unicode: false),
                        IsActived = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 500),
                        Avatar = c.String(),
                        BirthDay = c.DateTime(),
                        Status = c.Boolean(),
                        Gender = c.String(maxLength: 20),
                        Department = c.String(maxLength: 300),
                        Position = c.String(maxLength: 300),
                        Country = c.String(maxLength: 200),
                        CountryRegionCode = c.String(maxLength: 50),
                        City = c.String(maxLength: 100),
                        Postcode = c.String(maxLength: 10),
                        FileContentType = c.String(maxLength: 50),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AppUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserRoles", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserLogins", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserClaims", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserRoles", "IdentityRole_Id", "dbo.AppRoles");
            DropForeignKey("dbo.Role_Permission", "Function_ActionID", "dbo.Function_Action");
            DropForeignKey("dbo.Role_Permission", "AppRoleId", "dbo.AppRoles");
            DropForeignKey("dbo.Function_Action", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.Function_Action", "ActionId", "dbo.Action");
            DropIndex("dbo.AppUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.AppUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Role_Permission", new[] { "AppRoleId" });
            DropIndex("dbo.Role_Permission", new[] { "Function_ActionID" });
            DropIndex("dbo.Function_Action", new[] { "FunctionId" });
            DropIndex("dbo.Function_Action", new[] { "ActionId" });
            DropTable("dbo.AppUserLogins");
            DropTable("dbo.AppUserClaims");
            DropTable("dbo.AppUsers");
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserActivityLogs");
            DropTable("dbo.Tags");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.Slides");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Photos");
            DropTable("dbo.Permissions");
            DropTable("dbo.NewsTags");
            DropTable("dbo.Newses");
            DropTable("dbo.MenuTypes");
            DropTable("dbo.Menus");
            DropTable("dbo.Languages");
            DropTable("dbo.GroupSlides");
            DropTable("dbo.Footers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.Albums");
            DropTable("dbo.AppUserRoles");
            DropTable("dbo.AppRoles");
            DropTable("dbo.Role_Permission");
            DropTable("dbo.Functions");
            DropTable("dbo.Function_Action");
            DropTable("dbo.Action");
            DropTable("dbo.Abouts");
        }
    }
}
