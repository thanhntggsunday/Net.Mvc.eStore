using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Constants;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.Utilities;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class MenuService : IMenuService<MenuDto>
    {
        public MenuDto Create(MenuDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new Menu();
                item.Clone(dto);

                context.Menus.Add(item);
                context.SaveChanges();

                dto.ID = item.ID;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(MenuDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Menus.FirstOrDefault(x => x.ID == dto.ID);
                context.Menus.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<MenuDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<MenuDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Menus.AsQueryable().OrderByDescending(x => x.ModifiedDate);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new MenuDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<MenuDto> GetBottomMenuAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<MenuDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var items = context.Menus.AsQueryable()
                    .Where(x => x.GroupID == SystemConstants.BottomPosition && x.LanguageCode.Equals(cultureName))
                    .OrderBy(x => x.Order).ToList();
                
                foreach (var x in items)
                {
                    var item = new MenuDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<MenuDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            var resutl = new List<MenuDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Menus.AsQueryable().OrderByDescending(x => x.ModifiedDate);

                var items = queryable.Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();

                foreach (var x in items)
                {
                    var item = new MenuDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction = Utilities.CalculateForPagerOfTransaction(transaction, queryable.Count(), pageSize, currentPageNumber);
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public MenuDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            var resutl = new MenuDto();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Menus.FirstOrDefault(x => x.ID == id.ToString());

                resutl.Clone(item);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<MenuDto> GetTopMenuAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<MenuDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var items = context.Menus.AsQueryable()
                    .Where(x => x.GroupID == SystemConstants.TopPosition && x.LanguageCode.Equals(cultureName))
                    .OrderBy(x => x.Order).ToList();

                foreach (var x in items)
                {
                    var item = new MenuDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public void Update(MenuDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Menus.FirstOrDefault(x => x.ID == dto.ID);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}