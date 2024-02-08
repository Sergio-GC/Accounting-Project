﻿using System.ComponentModel.DataAnnotations;

namespace Accounting_EF_Base.Entities
{
    public class SiblingRelationship
    {
        [Key]
        public int Id { get; set; }
        public int KidId1 { get; set; }
        public virtual Kid Kid1 { get; set; }
        public int KidId2 { get; set; }
        public virtual Kid Kid2 { get; set; }
    }
}
