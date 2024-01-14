using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Galerie_Arta_Partea2.Models
{
    public class Listă_tablouri
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Programare_vizualizare))]
        public int Programare_vizualizareID { get; set; }
        public int TablouID { get; set; }
    }
}
