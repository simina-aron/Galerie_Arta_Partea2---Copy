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
    public class Tablou
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Denumire { get; set; }
        public DateTime DataRealizare { get; set; }
        public string Dimensiune { get; set; }
        public decimal Pret { get; set; }
        public string Descriere { get; set; }

        // Cheia străină pentru pictor
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Pictor))]
        public int PictorID { get; set; }

        public string Poza { get; set; }

        [OneToMany]
        public List<Listă_tablouri> Listă_tablouri { get; set; }
    }
}
