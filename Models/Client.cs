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
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        // Relația cu Programare_vizualizare (un client poate avea mai multe programări de vizualizare)
        [OneToMany]
        public List<Programare_vizualizare> Programare_Vizualizare { get; set; }
    }
}

