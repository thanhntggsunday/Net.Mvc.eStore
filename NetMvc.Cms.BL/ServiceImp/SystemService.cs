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
    public class SystemService : ISystemService<SystemConfigDto>
    {
        public SystemConfigDto Create(SystemConfigDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new SystemConfig();
                item.Clone(dto);

                context.SystemConfigs.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(SystemConfigDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.SystemConfigs.FirstOrDefault(x => x.ID == dto.ID);
                context.SystemConfigs.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<SystemConfigDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<SystemConfigDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.SystemConfigs.AsQueryable().OrderByDescending(x => x.ModifiedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new SystemConfigDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<SystemConfigDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<SystemConfigDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.SystemConfigs.AsQueryable().OrderByDescending(x => x.ModifiedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new SystemConfigDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public SystemConfigDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new SystemConfigDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.SystemConfigs.FirstOrDefault(x => x.ID == (int) id);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(SystemConfigDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.SystemConfigs.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}