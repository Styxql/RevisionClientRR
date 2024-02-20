using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionClient.Models
{
    public class Pilote
    {
        public Pilote()
        {
            VoiturePilote = new HashSet<Voiture>();
        }
        [Key]
        [Column("idpilote")]
        public int PiloteId { get; set; }

        [Column("pilotenom")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column("piloteprenom")]
        [StringLength(50)]
        public string Prenom { get; set; }


        [Column("piloteage")]
        public int Age { get; set; }


        [InverseProperty("PiloteDeLaVoiture")]
        public virtual ICollection<Voiture> VoiturePilote { get; set; }
    }
}
