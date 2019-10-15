using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084MidtermF2019.Models
{
    public partial class Riding
    {
        public Riding()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int RidingId { get; set; }
        [Required]
        [Display(Name = "Riding")]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("Riding")]
        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
