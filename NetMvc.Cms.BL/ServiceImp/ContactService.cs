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
    public class ContactService : IContactService<ContactDto>
    {
        public ContactDto Create(ContactDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var entity = new Contact();
            entity.Clone(dto);

            using (var context = new NetMvcDbContext())
            {
                entity.Clone(dto);

                context.Contacts.Add(entity);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            dto.ID = entity.ID;

            return dto;
        }

        public void Delete(ContactDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Contacts.FirstOrDefault(x => x.ID == dto.ID);
                context.Contacts.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<ContactDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<ContactDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Contacts.AsQueryable()
                    .Where(x => x.LanguageCode.Equals(cultureName) && x.Status == true)
                    .OrderBy(x => x.Title);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new ContactDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<ContactDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<ContactDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Contacts.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName))
                    .OrderBy(x => x.Title);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new ContactDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public ContactDto GetDefaultContact(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new ContactDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Contacts
                    .Where(x => x.LanguageCode.Equals(cultureName) && x.Status == true).Take(1).ToList().ElementAt(0);
                              
                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public ContactDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new ContactDto();
            transaction = new TransactionalInformation();

            var itemId = Int32.Parse(id.ToString());

            using (var context = new NetMvcDbContext())
            {
                var item = context.Contacts.FirstOrDefault(x => x.ID == itemId);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(ContactDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Contacts.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}

