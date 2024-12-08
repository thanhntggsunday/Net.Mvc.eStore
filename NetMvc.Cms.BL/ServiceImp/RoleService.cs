using System;
using System.Collections.Generic;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.BL.ServiceImp
{
    public class RoleService : IRoleService<AppRoleDto>
    {
        public AppRoleDto Create(AppRoleDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppRoleDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public List<AppRoleDto> GetAll(string cultureName, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public List<AppRoleDto> GetDataPaging(string cultureName, int currentPageNumber, int pageSize, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public AppRoleDto GetItemByID(object id, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(AppRoleDto entity, out TransactionalInformation transaction)
        {
            throw new NotImplementedException();
        }
    }
}
