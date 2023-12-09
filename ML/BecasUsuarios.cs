using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class BecasUsuarios
    {
        public int IdBecasUsuarios { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Becas Becas { get; set; } 
        public List<object> Beca {  get; set; }

    }
}
