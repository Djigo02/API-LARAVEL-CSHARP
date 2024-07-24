using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDesktop.Model
{
    public class Campus
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string nomCampus { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public string departement { get; set; }
        public string region { get; set; }
        public string etat { get; set; }
    }
}
