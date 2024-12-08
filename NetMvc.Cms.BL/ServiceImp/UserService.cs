using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NetMvc.Cms.BL.Extensions;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class UserService : IUserService<AppUserDto>
    {
        public AppUserDto Create(AppUserDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = new AppUser();
                item.Clone(dto);

                context.Users.Add(item);
                context.SaveChanges();

                dto.Id = item.Id;
                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return dto;
        }

        public void Delete(AppUserDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Users.FirstOrDefault(x => x.Id == dto.Id);
                context.Users.Remove(item);
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }

        public List<AppUserDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            var resutl = new List<AppUserDto>();
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var queryable = context.Users.AsQueryable().OrderBy(x => x.Email);

                var items = queryable.ToList();

                foreach (var x in items)
                {
                    var item = new AppUserDto();
                    item.Clone(x);
                    resutl.Add(item);
                }

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }

            return resutl;
        }

        public List<AppUserDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public AppUserDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public string[] GetUserRoles()
        {
            var rolesOfCurrentUser = new List<string>();

            using (NetMvcDbContext context = new NetMvcDbContext())
            {
                // var currentUserName = HttpContext.Current.User.Identity.Name;
                var currentUser = context.Users.FirstOrDefault(x => x.Email == HttpContext.Current.User.Identity.Name);

                if (currentUser != null)
                {
                    foreach (var r in currentUser.Roles)
                    {
                        string roleName = "";
                        var role = context.Roles.FirstOrDefault(o => o.Id == r.RoleId);
                        roleName = role.Name;
                        //thêm thông tin role of user vào danh sách
                        rolesOfCurrentUser.Add(roleName);
                    }
                }

                return rolesOfCurrentUser.ToArray();
            }
            
        }

        public string[] GetUserRoles(string email)
        {
            var rolesOfCurrentUser = new List<string>();

            using (NetMvcDbContext context = new NetMvcDbContext())
            {
                // var currentUserName = HttpContext.Current.User.Identity.Name;
                var currentUser = context.Users.FirstOrDefault(x => x.Email == email);

                if (currentUser != null)
                {
                    foreach (var r in currentUser.Roles)
                    {
                        string roleName = "";
                        var role = context.Roles.FirstOrDefault(o => o.Id == r.RoleId);
                        roleName = role.Name;
                        //thêm thông tin role of user vào danh sách
                        rolesOfCurrentUser.Add(roleName);
                    }
                }

                return rolesOfCurrentUser.ToArray();
            }

        }

        public void Update(AppUserDto dto, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();

            using (var context = new NetMvcDbContext())
            {
                var item = context.Users.FirstOrDefault(x => x.Id == dto.Id);
                item.Clone(dto);

                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("ok");
            }
        }
    }
}
