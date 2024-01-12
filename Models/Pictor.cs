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
    public class Pictor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public DateTime? DataDeces { get; set; }  // Folosim DateTime? pentru a permite valori nule
        public string Nationalitate { get; set; }

        // Lista de tablouri pictate de artist
        [OneToMany(CascadeOperations = CascadeOperation.All)]  // Adăugăm CascadeOperations pentru a gestiona operațiile asupra listei
        public List<Tablou> ListaTablouri { get; set; }

        // Relația cu Programare_vizualizare (un pictor poate fi asociat cu mai multe programări de vizualizare)
        [OneToMany]
        public List<Programare_vizualizare> ProgramariVizualizare { get; set; }
    }
}

