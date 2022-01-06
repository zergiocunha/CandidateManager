
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeCandidatos.Models
{
    [Table("candidateexperiences")]
    public class CandidateExperience
    {
        [Key]
        public int IdCandidateExperience { get; set; }
        [ForeignKey("IdCandidate")]
        public int IdCandidate { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [MaxLength(100)]
        public string Job { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsertDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifyDate { get; set; }


    }

    
}
