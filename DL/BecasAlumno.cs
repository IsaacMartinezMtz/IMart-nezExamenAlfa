using System;
using System.Collections.Generic;

namespace DL;

public partial class BecasAlumno
{
    public int IdAsignarBecas { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdBeca { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Beca? IdBecaNavigation { get; set; }
    public object Alumno { get; set; }
}
