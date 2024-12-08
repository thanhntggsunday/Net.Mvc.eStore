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
    public class ProductService : BaseService, IProductService<ProductDto>
    {
        public ProductDto Create(ProductDto dto, out TransactionalInformation transaction)
        {

            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new Product();
                item.Clone(dto);

                context.Products.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(ProductDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Products.FirstOrDefault(x => x.ID == dto.ID);
                context.Products.Remove(item);

                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<ProductDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };

                resutl = queryable.Where(x=> x.LanguageCode == cultureName && x.Status == true)
                    .OrderBy(x => x.Title).ToList();

               
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };

                queryable= queryable.Where(x => x.LanguageCode == cultureName && x.Status == true);
                resutl = queryable
                    .OrderBy(x=>x.Title)
                    .Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public ProductDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new ProductDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedDate = o.ModifiedDate,
                        ModifiedBy = o.ModifiedBy,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };


                var itemID = Int64.Parse(id.ToString());

                resutl = queryable.FirstOrDefault(x => x.ID == itemID);
                   
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> GetProductByCateIdPaging(string cultureName, long cateID, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedDate = o.ModifiedDate,
                        ModifiedBy = o.ModifiedBy,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };

                queryable = queryable.Where(x =>
                    x.LanguageCode == cultureName && x.Status == true && x.CategoryID == cateID);

                resutl = queryable
                    .OrderBy(x => x.Title)
                    .Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> GetRelatedProducts(string cultureName, long cateID, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Products.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName) && x.CategoryID == cateID)
                    .OrderByDescending(x => x.UpTopHot);

                var items = queryable.Take(4);

                foreach (var x in items)
                {
                    var item = new ProductDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> GetTopList(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Products.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderByDescending(x => x.UpTopHot);

                var items = queryable.Take(6);

                foreach (var x in items)
                {
                    var item = new ProductDto();
                    item.Clone(x);
                    resutl.Add(item);
                }
                
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> SearchProducts(string cultureName, string keyWords, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };

                queryable = queryable.Where(x => x.LanguageCode == cultureName
                                                 && x.Status == true
                                                 && (x.Title.Contains(keyWords) || x.Description.Contains(keyWords)));
                resutl = queryable
                    .OrderBy(x => x.Title)
                    .Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductDto> GetDataTablePaging(string cultureName, int itemsSkipCount, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable =
                    from o in context.Products
                    join c in context.ProductCategories on o.CategoryID equals c.ID
                    select new ProductDto()
                    {
                        CreatedBy = o.CreatedBy,
                        CreatedDate = o.CreatedDate,
                        Description = o.Description,
                        ID = o.ID,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedDate = o.ModifiedDate,
                        CategoryID = o.CategoryID,
                        Images = o.Images,
                        LanguageCode = o.LanguageCode,
                        MetaDescription = o.MetaDescription,
                        MetaTitle = o.MetaTitle,
                        MetaKeywords = o.MetaKeywords,
                        Source = o.Source,
                        Status = o.Status,
                        Title = o.Title,
                        UpTopHot = o.UpTopHot,
                        UpTopNew = o.UpTopNew,
                        ViewCount = o.ViewCount,
                        Code = o.Code,
                        Detail = o.Detail,
                        Price = o.Price,

                        Category = new ProductCategoryDto()
                        {
                            ID = c.ID,
                            MetaKeywords = c.MetaKeywords,
                            MetaTitle = c.MetaTitle,
                            MetaDescription = c.MetaDescription
                        }
                    };

                queryable = queryable.Where(x => x.LanguageCode == cultureName && x.Status == true);
                resutl = queryable
                    .OrderBy(x => x.Title)
                    .Skip(itemsSkipCount).Take(pageSize).ToList();

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(ProductDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Products.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}
