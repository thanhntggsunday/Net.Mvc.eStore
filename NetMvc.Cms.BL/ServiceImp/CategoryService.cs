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
    public class CategoryService : ICategoryService<CategoryDto>
    {
        public CategoryDto Create(CategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var entity = new Category();
            entity.Clone(dto);

            using (var context = new NetMvcDbContext())
            {
                entity.Clone(dto);

                context.Categories.Add(entity);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            dto.ID = entity.ID;

            return dto;
        }

        public void Delete(CategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Categories.FirstOrDefault(x => x.ID == dto.ID);
                context.Categories.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<CategoryDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<CategoryDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Categories.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderByDescending(x => x.CreatedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new CategoryDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<CategoryDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<CategoryDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Categories.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderByDescending(x => x.CreatedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new CategoryDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public CategoryDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new CategoryDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var itemID = Int64.Parse(id.ToString());
                var item = context.Categories.FirstOrDefault(x => x.ID == itemID);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(CategoryDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Categories.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}
