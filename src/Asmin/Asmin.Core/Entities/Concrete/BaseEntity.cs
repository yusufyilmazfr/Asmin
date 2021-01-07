using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Core.Entities.Concrete
{
    /// <summary>
    /// BaseEntity provides common properties to database entities.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        /// Generic unique key.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Date of entity creation.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date of last modification.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
