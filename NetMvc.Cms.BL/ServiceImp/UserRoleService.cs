using System;
using System.Collections.Generic;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class UserRoleService : IUserRoleService<AppUserRolesDto>
    {
        public AppUserRolesDto Create(AppUserRolesDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUserRolesDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public List<AppUserRolesDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public List<AppUserRolesDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public AppUserRolesDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUserRolesDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
