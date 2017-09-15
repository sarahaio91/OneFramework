using System;
using System.ComponentModel.DataAnnotations.Schema;
using OneFramework.Auth.Domain.Entities.User;

namespace OneFramework.Auth.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public string CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public Guid UpdatedById { get; set; }
        public ApplicationUser UpdatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedDate { get; set; }
    }
}
