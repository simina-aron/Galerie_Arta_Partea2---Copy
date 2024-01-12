using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Galerie_Arta_Partea2.Models
{
    public class Compoziție_și_îngrijire
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string MaterialCompozitie { get; set; }
        public string TipInscriptionare { get; set; }
        public string IngrijireRecomandata { get; set; }
        public string StareConservare { get; set; }

        // Relația cu Programare_vizualizare (o compoziție și ingrijire poate fi asociată cu mai multe programări de vizualizare)
        [OneToMany]
        public List<Programare_vizualizare> Programare_Vizualizare { get; set; }
    }
}

