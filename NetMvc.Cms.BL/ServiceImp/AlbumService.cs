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
    public class AlbumService : IAlbumService<AlbumDto>
    {
        
        public AlbumDto Create(AlbumDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var entity = new Album();
            entity.Clone(dto);

            using (var context = new NetMvcDbContext())
            {
                entity.Clone(dto);

                context.Albums.Add(entity);
                context.SaveChanges();
               
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            dto.ID = entity.ID;
           
            return dto;
        }

        public void Delete(AlbumDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Albums.FirstOrDefault(x => x.ID == dto.ID);
                context.Albums.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<AlbumDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<AlbumDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Albums.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName) && x.Status == true)
                    .OrderBy(x => x.Order);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new AlbumDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<AlbumDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<AlbumDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Albums.AsQueryable().Where(x => x.LanguageCode.Equals(cultureName) && x.Status == true)
                    .OrderBy(x => x.CreatedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new AlbumDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public AlbumDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new AlbumDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var itemID = Int64.Parse(id.ToString());
                var item = context.Albums.FirstOrDefault(x => x.ID == itemID);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }
        
        public void Update(AlbumDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Albums.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}
