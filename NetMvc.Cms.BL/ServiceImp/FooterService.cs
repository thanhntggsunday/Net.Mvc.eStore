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
    public class FooterService : IFooterService<FooterDto>
    {
        public List<FooterDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<FooterDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Footers.AsQueryable().OrderBy(x => x.Title);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new FooterDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<FooterDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<FooterDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Footers.AsQueryable().OrderBy(x => x.Title);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new FooterDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public FooterDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new FooterDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Footers.FirstOrDefault(x => x.ID == id.ToString());

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }


        public FooterDto Create(FooterDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var entity = new Footer();
            entity.Clone(dto);

            using (var context = new NetMvcDbContext())
            {
                entity.Clone(dto);

                context.Footers.Add(entity);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            dto.ID = entity.ID;

            return dto;
        }

        public void Delete(FooterDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Footers.FirstOrDefault(x => x.ID == dto.ID);
                context.Footers.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public void Update(FooterDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Footers.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public string GetDefaultFooter(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = String.Empty;
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                resutl = context.Footers.AsQueryable()
                    .Where(x => x.LanguageCode == cultureName && x.Status == true).Take(1).ToList().ElementAt(0)?.ContentHtml;
               
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }
    }
}