using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Model.Entities;
using Action = NetMvc.Cms.Model.Entities.Action;

namespace NetMvc.Cms.BL.Extensions
{
    public static class Extension
    {
        #region About

        public static void Clone(this About item, AboutDto source)
        {
            item.ContentHtml = source.ContentHtml;
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this AboutDto item, About source)
        {
            item.ContentHtml = source.ContentHtml;
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        #endregion About

        #region Action

        public static void Clone(this ActionDto item, Action source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Name = source.Name;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Action item, ActionDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Name = source.Name;
            item.StrStatus = source.StrStatus;
        }

        #endregion Action

        #region Album

        public static void Clone(this AlbumDto item, Album source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Album item, AlbumDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        #endregion Album

        #region Category

        public static void Clone(this CategoryDto item, Category source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.IsIntroduced = source.IsIntroduced;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Category item, CategoryDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.Description = source.Description;
            item.ID = source.ID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaKeywords = source.MetaKeywords;
            item.MetaTitle = source.MetaTitle;
            item.Title = source.Title;
            item.Status = source.Status;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.IsIntroduced = source.IsIntroduced;
            item.StrStatus = source.StrStatus;
        }

        #endregion Category

        #region Contact

        public static void Clone(this ContactDto item, Contact source)
        {
            item.ID = source.ID;
            item.LanguageCode = source.LanguageCode;
            item.Title = source.Title;
            item.Status = source.Status;
            item.ContentHtml = source.ContentHtml;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Contact item, ContactDto source)
        {
            item.ID = source.ID;
            item.LanguageCode = source.LanguageCode;
            item.Title = source.Title;
            item.Status = source.Status;
            item.ContentHtml = source.ContentHtml;
            item.StrStatus = source.StrStatus;
        }

        #endregion Contact

        #region Feedback

        public static void Clone(this FeedbackDto item, Feedback source)
        {
            item.Address = source.Address;
            item.Company = source.Company;
            item.CreatedDate = source.CreatedDate;
            item.Email = source.Email;
            item.ID = source.ID;
            item.IsReaded = source.IsReaded;
            item.Message = source.Message;
            item.Name = source.Name;
            item.Phone = source.Phone;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Feedback item, FeedbackDto source)
        {
            item.Address = source.Address;
            item.Company = source.Company;
            item.CreatedDate = source.CreatedDate;
            item.Email = source.Email;
            item.ID = source.ID;
            item.IsReaded = source.IsReaded;
            item.Message = source.Message;
            item.Name = source.Name;
            item.Phone = source.Phone;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        #endregion Feedback

        #region Footer

        public static void Clone(this FooterDto item, Footer source)
        {
            item.ContentHtml = source.ContentHtml;
            item.ID = source.ID;
            item.LanguageCode = source.LanguageCode;
            item.Status = source.Status;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Footer item, FooterDto source)
        {
            item.ContentHtml = source.ContentHtml;
            item.ID = source.ID;
            item.LanguageCode = source.LanguageCode;
            item.Status = source.Status;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        #endregion Footer

        #region Function

        public static void Clone(this FunctionDto item, Function source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.CssClass = source.CssClass;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.IsLocked = source.IsLocked;
            item.Link = source.Link;
            item.Name = source.Name;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.Target = source.Target;
            item.Text = source.Text;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Function item, FunctionDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.CssClass = source.CssClass;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.IsLocked = source.IsLocked;
            item.Link = source.Link;
            item.Name = source.Name;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.Target = source.Target;
            item.Text = source.Text;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.StrStatus = source.StrStatus;
        }

        #endregion Function

        #region GroupSlide

        public static void Clone(this GroupSlideDto item, GroupSlide source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsActived = source.IsActived;
            item.Name = source.Name;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this GroupSlide item, GroupSlideDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsActived = source.IsActived;
            item.Name = source.Name;
            item.StrStatus = source.StrStatus;
        }

        #endregion GroupSlide

        #region Language

        public static void Clone(this LanguageDto item, Language source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsActived = source.IsActived;
            item.Name = source.Name;
            item.IsDefault = source.IsDefault;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Language item, LanguageDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsActived = source.IsActived;
            item.Name = source.Name;
            item.IsDefault = source.IsDefault;
            item.StrStatus = source.StrStatus;
        }

        #endregion Language

        #region Menu

        public static void Clone(this MenuDto item, Menu source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.CssClass = source.CssClass;
            item.GroupID = source.GroupID;
            item.IsLocked = source.IsLocked;
            item.Link = source.Link;
            item.LanguageCode = source.LanguageCode;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.Target = source.Target;
            item.Text = source.Text;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Menu item, MenuDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.CssClass = source.CssClass;
            item.GroupID = source.GroupID;
            item.IsLocked = source.IsLocked;
            item.Link = source.Link;
            item.LanguageCode = source.LanguageCode;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.Target = source.Target;
            item.Text = source.Text;
            item.StrStatus = source.StrStatus;
        }

        #endregion Menu

        #region MenuType

        public static void Clone(this MenuTypeDto item, MenuType source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.IsActived = source.IsActived;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this MenuType item, MenuTypeDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.IsActived = source.IsActived;
            item.StrStatus = source.StrStatus;
        }

        #endregion MenuType

        #region News

        public static void Clone(this NewsDto item, News source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.CategoryID = source.CategoryID;
            item.ContentHtml = source.ContentHtml;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.PublishedDate = source.PublishedDate;
            item.MetaKeywords = source.MetaKeywords;
            item.RelatedNewses = source.RelatedNewses;
            item.Source = source.Source;
            item.Status = source.Status;
            item.Title = source.Title;
            item.UpTopHot = source.UpTopHot;
            item.UpTopNew = source.UpTopNew;
            item.ViewCount = source.ViewCount;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this News item, NewsDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.CategoryID = source.CategoryID;
            item.ContentHtml = source.ContentHtml;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.PublishedDate = source.PublishedDate;
            item.MetaKeywords = source.MetaKeywords;
            item.RelatedNewses = source.RelatedNewses;
            item.Source = source.Source;
            item.Status = source.Status;
            item.Title = source.Title;
            item.UpTopHot = source.UpTopHot;
            item.UpTopNew = source.UpTopNew;
            item.ViewCount = source.ViewCount; 
            item.StrStatus = source.StrStatus;
        }

        #endregion News

        #region NewTag

        public static void Clone(this NewsTagDto item, NewsTag source)
        {
            item.TagID = source.TagID;
            item.NewsID = source.NewsID;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this NewsTag item, NewsTagDto source)
        {
            item.TagID = source.TagID;
            item.NewsID = source.NewsID;
            item.StrStatus = source.StrStatus;
        }

        #endregion NewTag

        #region Photo

        public static void Clone(this PhotoDto item, Photo source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.AlbumID = source.AlbumID;
            item.Images = source.Images;
            item.Status = source.Status;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Photo item, PhotoDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.AlbumID = source.AlbumID;
            item.Images = source.Images;
            item.Status = source.Status;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        #endregion Photo

        #region Product category

        public static void Clone(this ProductCategoryDto item, ProductCategory source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.MetaKeywords = source.MetaKeywords;
            item.Status = source.Status;
            item.Title = source.Title;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this ProductCategory item, ProductCategoryDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.MetaKeywords = source.MetaKeywords;
            item.Status = source.Status;
            item.Title = source.Title;
            item.Order = source.Order;
            item.ParentID = source.ParentID;
            item.StrStatus = source.StrStatus;
        }

        #endregion Product category

        #region Product

        public static void Clone(this ProductDto item, Product source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.CategoryID = source.CategoryID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.MetaKeywords = source.MetaKeywords;
            item.Source = source.Source;
            item.Status = source.Status;
            item.Title = source.Title;
            item.UpTopHot = source.UpTopHot;
            item.UpTopNew = source.UpTopNew;
            item.ViewCount = source.ViewCount;
            item.Code = source.Code;
            item.Detail = source.Detail;
            item.Price = source.Price;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Product item, ProductDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedBy = source.ModifiedBy;
            item.ModifiedDate = source.ModifiedDate;
            item.CategoryID = source.CategoryID;
            item.Images = source.Images;
            item.LanguageCode = source.LanguageCode;
            item.MetaDescription = source.MetaDescription;
            item.MetaTitle = source.MetaTitle;
            item.MetaKeywords = source.MetaKeywords;
            item.Source = source.Source;
            item.Status = source.Status;
            item.Title = source.Title;
            item.UpTopHot = source.UpTopHot;
            item.UpTopNew = source.UpTopNew;
            item.ViewCount = source.ViewCount;
            item.Code = source.Code;
            item.Detail = source.Detail;
            item.Price = source.Price;
            item.StrStatus = source.StrStatus;
        }

        #endregion Product

        #region Slide

        public static void Clone(this SlideDto item, Slide source)
        {
            item.Description = source.Description;
            item.GroupID = source.GroupID;
            item.ID = source.ID;
            item.Images = source.Images;
            item.Link = source.Link;
            item.Name = source.Name;
            item.Order = source.Order;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Slide item, SlideDto source)
        {
            item.Description = source.Description;
            item.GroupID = source.GroupID;
            item.ID = source.ID;
            item.Images = source.Images;
            item.Link = source.Link;
            item.Name = source.Name;
            item.Order = source.Order;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
        }

        #endregion Slide

        #region SystemConfig

        public static void Clone(this SystemConfigDto item, SystemConfig source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.UniqueKey = source.UniqueKey;
            item.Unit = source.Unit;
            item.Value = source.Value;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this SystemConfig item, SystemConfigDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.Description = source.Description;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsDeleted = source.IsDeleted;
            item.Name = source.Name;
            item.UniqueKey = source.UniqueKey;
            item.Unit = source.Unit;
            item.Value = source.Value;
            item.StrStatus = source.StrStatus;
        }

        #endregion SystemConfig

        #region Tag

        public static void Clone(this TagDto item, Tag source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsDeleted = source.IsDeleted;
            item.IsActived = source.IsActived;
            item.IsDefault = source.IsDefault;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Tag item, TagDto source)
        {
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.ID = source.ID;
            item.ModifiedDate = source.ModifiedDate;
            item.ModifiedBy = source.ModifiedBy;
            item.IsDeleted = source.IsDeleted;
            item.IsActived = source.IsActived;
            item.IsDefault = source.IsDefault;
            item.Title = source.Title;
            item.StrStatus = source.StrStatus;
        }

        #endregion Tag

        #region UserActivityLogDto

        public static void Clone(this UserActivityLogDto item, UserActivityLog source)
        {
            item.ActionDate = source.ActionDate;
            item.ActionName = source.ActionName;
            item.ID = source.ID;
            item.IPAddress = source.IPAddress;
            item.SessionID = source.SessionID;
            item.UserName = source.UserName;
            item.StrStatus = source.StrStatus;
        }

        #endregion UserActivityLogDto

        #region Permission

        public static void Clone(this PermissionDto item, Permission source)
        {
            item.ID = source.ID;
            item.FunctionID = source.FunctionID;
            item.GroupID = source.GroupID;
            item.RoleID = source.RoleID;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Permission item, PermissionDto source)
        {
            item.ID = source.ID;
            item.FunctionID = source.FunctionID;
            item.GroupID = source.GroupID;
            item.RoleID = source.RoleID;
            item.StrStatus = source.StrStatus;
        }

        #endregion Permission

        #region User

        public static void Clone(this AppUserDto item, AppUser source)
        {
            item.AccessFailedCount = source.AccessFailedCount;
            item.Address = source.Address;
            item.Avatar = source.Avatar;
            item.BirthDay = source.BirthDay;
            item.City = source.City;
            item.Country = source.Country;
            item.CountryRegionCode = source.CountryRegionCode;
            item.Department = source.Department;
            item.Email = source.Email;
            item.EmailConfirmed = source.EmailConfirmed;
            item.FullName = source.FullName;
            item.Gender = source.Gender;
            item.Id = source.Id;
            item.LockoutEnabled = source.LockoutEnabled;
            item.LockoutEndDateUtc = source.LockoutEndDateUtc;
            item.PasswordHash = source.PasswordHash;
            item.PhoneNumber = source.PhoneNumber;
            item.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            item.Position = source.Position;
            item.Postcode = source.Postcode;
            item.SecurityStamp = source.SecurityStamp;
            item.Status = source.Status;
            item.TwoFactorEnabled = source.TwoFactorEnabled;
            item.UserName = source.UserName;
        }

        public static void Clone(this AppUser item, AppUserDto source)
        {
            item.AccessFailedCount = source.AccessFailedCount;
            item.Address = source.Address;
            item.Avatar = source.Avatar;
            item.BirthDay = source.BirthDay;
            item.City = source.City;
            item.Country = source.Country;
            item.CountryRegionCode = source.CountryRegionCode;
            item.Department = source.Department;
            item.Email = source.Email;
            item.EmailConfirmed = source.EmailConfirmed;
            item.FullName = source.FullName;
            item.Gender = source.Gender;
            item.Id = source.Id;
            item.LockoutEnabled = source.LockoutEnabled;
            item.LockoutEndDateUtc = source.LockoutEndDateUtc;
            item.PasswordHash = source.PasswordHash;
            item.PhoneNumber = source.PhoneNumber;
            item.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            item.Position = source.Position;
            item.Postcode = source.Postcode;
            item.SecurityStamp = source.SecurityStamp;
            item.Status = source.Status;
            item.TwoFactorEnabled = source.TwoFactorEnabled;
            item.UserName = source.UserName;
        }

        #endregion User

        #region Order

        public static void Clone(this OrderDto item, Order source)
        {
            item.ID = source.ID;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.CustomerAddress = source.CustomerAddress;
            item.CustomerEmail = source.CustomerEmail;
            item.CustomerMessage = source.CustomerMessage;
            item.CustomerMobile = source.CustomerMobile;
            item.CustomerName = source.CustomerName;
            item.PaymentMethod = source.PaymentMethod;
            item.PaymentStatus = source.PaymentStatus;
            item.Total = source.Total;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this Order item, OrderDto source)
        {
            item.ID = source.ID;
            item.Status = source.Status;
            item.StrStatus = source.StrStatus;
            item.CreatedBy = source.CreatedBy;
            item.CreatedDate = source.CreatedDate;
            item.CustomerAddress = source.CustomerAddress;
            item.CustomerEmail = source.CustomerEmail;
            item.CustomerMessage = source.CustomerMessage;
            item.CustomerMobile = source.CustomerMobile;
            item.CustomerName = source.CustomerName;
            item.PaymentMethod = source.PaymentMethod;
            item.PaymentStatus = source.PaymentStatus;
            item.Total = source.Total;
        }

        #endregion Order

        #region OrderDetail

        public static void Clone(this OrderDetailsDto item, OrderDetail source)
        {
            item.OrderID = source.OrderID;
            item.ProductID = source.ProductID;
            
            item.Quantitty = source.Quantitty;
            item.StrStatus = source.StrStatus;
        }

        public static void Clone(this OrderDetail item, OrderDetailsDto source)
        {
            item.OrderID = source.OrderID;
            item.ProductID = source.ProductID;
            item.Quantitty = source.Quantitty;
            item.StrStatus = source.StrStatus;
        }

        #endregion OrderDetail
    }
}