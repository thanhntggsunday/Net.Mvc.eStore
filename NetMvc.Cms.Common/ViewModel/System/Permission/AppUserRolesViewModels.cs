using System.Collections.Generic;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Common.ViewModel.System.Permission
{
    public class AppUserRolesViewModels<Object> : ApiResult<Object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppUserRolesViewModels"/> class.
        /// </summary>
        public AppUserRolesViewModels()
        {
            UserRolesList = new HashSet<AppUserRolesDto>();
        }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the RoleName
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the userRolesList
        /// </summary>
        public ICollection<AppUserRolesDto> UserRolesList { get; set; }

        public ICollection<AppUserDto> Users { get; set; }

        public ICollection<AppRoleDto> Roles { get; set; }
    }
}