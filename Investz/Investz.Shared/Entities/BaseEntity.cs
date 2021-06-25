using System;
using System.ComponentModel.DataAnnotations;

namespace Investz.Shared.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        /// <value>The identifier of the entity.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date of the creation.
        /// </summary>
        /// <value>The date of the creation.</value>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the modification.
        /// </summary>
        /// <value>The date of the modification.</value>
        public DateTimeOffset ModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the amount to created by.
        /// </summary>
        /// <value>The amount to created by.</value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the amount to modified by.
        /// </summary>
        /// <value>The amount to modified by.</value>
        public int ModifiedBy { get; set; }
    }
}