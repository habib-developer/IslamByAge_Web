using IslamByAge.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IslamByAge.Core.Domain
{
    public class Topic:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
    }
}
