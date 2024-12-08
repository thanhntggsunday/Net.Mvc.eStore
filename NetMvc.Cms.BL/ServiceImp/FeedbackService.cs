using System;
using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.Utilities;
using NetMvc.Cms.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class FeedbackService : BaseService, IFeedbackService<FeedbackDto>
    {
       
        public List<FeedbackDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<FeedbackDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Feedbacks.AsQueryable().OrderByDescending(x => x.CreatedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new FeedbackDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<FeedbackDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<FeedbackDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Feedbacks.AsQueryable().OrderByDescending(x => x.CreatedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new FeedbackDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public FeedbackDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new FeedbackDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var itemID = Int64.Parse(id.ToString());
                var item = context.Feedbacks.FirstOrDefault(x => x.ID == itemID);

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public FeedbackDto Create(FeedbackDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            var entity = new Feedback();
            entity.Clone(dto);

            var context = GetContext();

            context.Feedbacks.Add(entity);
            context.SaveChanges();
            context.Dispose();

            dto.ID = entity.ID;
            transaction.ReturnStatus = true;

            return dto;

        }

        public void Delete(FeedbackDto entity, out TransactionalInformation transaction)
        {
            throw new System.NotImplementedException();
        }

        public void Update(FeedbackDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Feedbacks.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

    }
}