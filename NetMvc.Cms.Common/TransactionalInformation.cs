using System;
using System.Collections;
using System.Collections.Generic;

namespace NetMvc.Cms.Common
{
    public class TransactionalInformation
    {
        /// <summary>
        /// Gets or sets a value indicating whether ReturnStatus
        /// </summary>
        public bool ReturnStatus { get; set; }

        /// <summary>
        /// Gets or sets the ReturnMessage
        /// </summary>
        public List<String> ReturnMessage { get; set; }

        /// <summary>
        /// Gets or sets the ValidationErrors
        /// </summary>
        public Hashtable ValidationErrors { get; set; }

        /// <summary>
        /// Gets or sets the IsAuthenicated
        /// </summary>
        public Boolean IsAuthenicated { get; set; }

        /// <summary>
        /// Gets or sets the SortExpression
        /// </summary>
        public string SortExpression { get; set; }

        /// <summary>
        /// Gets or sets the SortDirection
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// Gets or sets the Pager
        /// </summary>
        public Pager Pager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionalInformation"/> class.
        /// </summary>
        public TransactionalInformation()
        {
            ReturnMessage = new List<String>();
            ReturnStatus = true;
            ValidationErrors = new Hashtable();
            IsAuthenicated = false;
            Pager = new Pager();
        }
    }
}
