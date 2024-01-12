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
    public class Programare_vizualizare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Descriere { get; set; }

        public DateTime Date { get; set; }

        // Cheia străină pentru tablou
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Tablou))]
        public int TablouID { get; set; }

        // Cheia străină pentru client
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Client))]
        public int ClientID { get; set; }
    }
}
