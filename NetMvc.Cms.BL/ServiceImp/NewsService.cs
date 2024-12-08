using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.Utilities;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class NewsService : INewsService<NewsDto>
    {
        public NewsDto Create(NewsDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new News();
                item.Clone(dto);

                context.Newses.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(NewsDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Newses.FirstOrDefault(x => x.ID == dto.ID);
                context.Newses.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<NewsDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };

                queryable = queryable.Where(x=> x.LanguageCode.Equals(cultureName)
                                            && x.Status == true)
                                      .OrderByDescending(x => x.ModifiedDate);

                resutl = queryable.ToList();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<NewsDto> GetDataByCategoryIdPaging(string cultureName, long cateID, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };


                resutl = queryable.Where(x => x.LanguageCode == cultureName && x.Status == true && x.ID == cateID)
                    .OrderByDescending(x => x.ModifiedDate).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<NewsDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };


                resutl = queryable.Where(x => x.LanguageCode == cultureName && x.Status == true)
                    .OrderByDescending(x => x.ModifiedDate).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<NewsDto> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };


                resutl = queryable.Where(x => x.LanguageCode == cultureName && x.Status == true)
                    .OrderByDescending(x => x.ModifiedDate).Skip(itemsSkipCount).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public NewsDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new NewsDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };

                var itemID = Int64.Parse(id.ToString());

                var items = queryable.Where(x => x.ID == itemID).ToList();
                resutl = items.ElementAt(0);
                
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<NewsDto> GetRelatedNewses(string cultureName, long cateID, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedDate = o.ModifiedDate,
                        ModifiedBy = o.ModifiedBy,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };

                queryable = queryable.Where(x => x.UpTopHot != null
                                                 && x.LanguageCode.Equals(cultureName)
                                                 && x.Status == true).Take(4)
                                     .OrderByDescending(x => x.ModifiedDate);

                resutl = queryable.ToList();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<NewsDto> GetTopList(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<NewsDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Newses
                    join c in context.Categories on o.CategoryID equals c.ID
                    select new NewsDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedDate = o.ModifiedDate,
                        ModifiedBy = o.ModifiedBy,
                        CategoryID = o.CategoryID,
                        ContentHtml = o.ContentHtml,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        PublishedDate = o.PublishedDate,
                        MetaKeywords = o.MetaKeywords,
                        RelatedNewses = o.RelatedNewses,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        CategoryName = c.MetaKeywords
                    };

                queryable = queryable.Where(x => x.UpTopHot != null 
                                             && x.LanguageCode.Equals(cultureName) 
                                             && x.Status == true
                                             )
                                            .OrderByDescending(x => x.ModifiedDate)
                                            .Take(4);

                resutl = queryable.ToList();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(NewsDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Newses.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}