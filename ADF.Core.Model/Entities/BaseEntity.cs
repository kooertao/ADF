using System;
using System.ComponentModel.DataAnnotations;

namespace ADF.Core.Model.Entities
{
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
