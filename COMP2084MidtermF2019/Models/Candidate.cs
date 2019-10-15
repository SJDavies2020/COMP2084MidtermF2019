using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084MidtermF2019.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        public int PartyId { get; set; }
        public int RidingId { get; set; }

        [ForeignKey("PartyId")]
        [InverseProperty("Candidate")]
        public virtual Party Party { get; set; }
        [ForeignKey("RidingId")]
        [InverseProperty("Candidate")]
        public virtual Riding Riding { get; set; }
    }
}
