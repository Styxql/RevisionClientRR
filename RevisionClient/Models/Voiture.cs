using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionClient.Models
{
    public class Voiture
    {
        [Key]
        [Column("idvoiture")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idvoiture { get; set; }

        [Key]
        [Column("idpilote")]
        public int Idpilote { get; set; }

        [Column("nomvoiture")]
        [StringLength(100)]
        public string NomVoiture { get; set; }


        [Column("anneesortie")]
        public int AnneeSortie { get; set; }

        [ForeignKey("Idpilote")]
        [InverseProperty("VoiturePilote")]
        public virtual Pilote PiloteDeLaVoiture { get; set; }
    }
}
