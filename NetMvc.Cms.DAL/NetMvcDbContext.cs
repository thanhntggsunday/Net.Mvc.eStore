using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.DAL
{
    public partial class NetMvcDbContext : IdentityDbContext<AppUser>
    {
        public NetMvcDbContext()
            : base("name=ModelContext")
        {
            Database.SetInitializer<NetMvcDbContext>(null);
        }


        public virtual DbSet<Role_Permission> Role_Permission { get; set; }
        public virtual DbSet<Function_Action> Function_Action { get; set; }
        public virtual DbSet<NetMvc.Cms.Model.Entities.Action> Actions { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public DbSet<IdentityUserRole> UserRoles { set; get; }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<GroupSlide> GroupSlides { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<NewsTag> NewsTags { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }       
        public virtual DbSet<Slide> Slides { get; set; }
       
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }     
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.CreateAspNetModel();

            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Album>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.CssClass)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.ParentID)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupSlide>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupSlide>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupSlide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.CssClass)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.ParentID)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.RelatedNewses)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<NewsTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.FunctionID)
                .IsUnicode(false);

            modelBuilder.Entity<Photo>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.UniqueKey)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserActivityLog>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<UserActivityLog>()
                .Property(e => e.SessionID)
                .IsUnicode(false);

            modelBuilder.Entity<UserActivityLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            //modelBuilder.Entity<Contact>()
            //    .Property(e => e.ID)
            //    .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LanguageCode)
                .IsUnicode(false);
        }

        public static NetMvcDbContext Create()
        {
            return new NetMvcDbContext();
        }
    }
}
