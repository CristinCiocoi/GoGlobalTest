using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace testProjectBackend.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}