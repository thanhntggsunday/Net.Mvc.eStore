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
    public class ProductCategoryService : IProductCategoryService<ProductCategoryDto>
    {
        public ProductCategoryDto Create(ProductCategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new ProductCategory();
                item.Clone(dto);

                context.ProductCategories.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(ProductCategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.ProductCategories.FirstOrDefault(x => x.ID == dto.ID);
                context.ProductCategories.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<ProductCategoryDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductCategoryDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.ProductCategories.AsQueryable().OrderByDescending(x => x.MetaTitle);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new ProductCategoryDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ProductCategoryDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ProductCategoryDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.ProductCategories.AsQueryable().OrderByDescending(x => x.ModifiedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new ProductCategoryDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public ProductCategoryDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new ProductCategoryDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var itemID = Int64.Parse(id.ToString());
                var item = context.ProductCategories.FirstOrDefault(x => x.ID == itemID);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(ProductCategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.ProductCategories.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}