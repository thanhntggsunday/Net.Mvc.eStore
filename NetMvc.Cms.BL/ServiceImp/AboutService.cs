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
    public class AboutService : BaseService, IAboutService<AboutDto>
    {
        public List<AboutDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<AboutDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Abouts.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderByDescending(x => x.ModifiedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new AboutDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<AboutDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<AboutDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Abouts.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderByDescending(x => x.ModifiedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new AboutDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public AboutDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new AboutDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var itemID = Int64.Parse(id.ToString());
                var item = context.Abouts.FirstOrDefault(x => x.ID == itemID);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public AboutDto Create(AboutDto dto, out TransactionalInformation transaction)
        {
            var resutl = new AboutDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new About();
                item.Clone(dto);

                context.Abouts.Add(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(AboutDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Abouts.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public void Delete(AboutDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Abouts.FirstOrDefault(x => x.ID == dto.ID);
                context.Abouts.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

        }
    }
}
