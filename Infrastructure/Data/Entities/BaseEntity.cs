using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities
{
    internal class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}