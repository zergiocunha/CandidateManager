
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeCandidatos.Models
{
    [Table("candidates")]
    public class Candidate
    {
        [Key]
        public int IdCandidate { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime? InsertDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifyDate { get; set; }

    }
}
