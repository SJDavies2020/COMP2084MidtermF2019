using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084MidtermF2019.Models
{
    public partial class Party
    {
        public Party()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int PartyId { get; set; }
        [Required]
        [Display(Name = "Party")]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }

        [InverseProperty("Party")]
        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
