using System.Collections.Generic;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Common.ViewModel.System
{
    public class RoleViewModel : TransactionalInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleViewModel"/> class.
        /// </summary>
        public RoleViewModel()
        {
            Roles = new List<AppRoleDto>();
        }

        /// <summary>
        /// Gets or sets the RoleId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the RoleName
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Roles
        /// </summary>
        public List<AppRoleDto> Roles { get; set; }
    }
}