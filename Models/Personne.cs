using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_personne_arpilabe.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Note { get; set; }
        public string Departement { get; set; }
        public string DateDeNaissance { get; set; }
    }
}