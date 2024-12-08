using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.Common.Utilities;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class SlideService : ISlideService<SlideDto>
    {
        public SlideDto Create(SlideDto dto, out TransactionalInformation transaction)
        {

            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new Slide();
                item.Clone(dto);

                context.Slides.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(SlideDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Slides.FirstOrDefault(x => x.ID == dto.ID);
                context.Slides.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<SlideDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<SlideDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Slides.AsQueryable().OrderBy(x => x.Name);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new SlideDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<SlideDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<SlideDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Slides.AsQueryable().OrderBy(x => x.Name);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new SlideDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public SlideDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new SlideDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Slides.FirstOrDefault(x => x.ID == (int) id);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(SlideDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Slides.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}