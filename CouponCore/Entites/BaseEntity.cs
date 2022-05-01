using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponCore.Entites
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Name must be 50 chars or less")]
        public virtual string Name { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}