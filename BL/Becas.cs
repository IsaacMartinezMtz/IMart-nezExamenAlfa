using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Becas
    {
        public static ML.Result GetBecas()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext context = new DL.ExamenAlfaContext())
                {
                    var query = (from becasA in context.BecasAlumnos
                                 join alumnos in context.Alumnos on becasA.IdAlumno equals alumnos.IdAlumno
                                 join becas in context.Becas on becasA.IdBeca equals becas.IdBecas
                                 select new
                                 {
                                     IdAlumno = alumnos.IdAlumno,
                                     NombreAlumno = alumnos.Nombre,
                                     IdBecas = becas.IdBecas,
                                     NombreBecas = becas.Nombre,


                                 }
                                 ).ToList();

                    

                    result.Objects = new List<object>();
                    if(query.Count > 0)
                    {
                        foreach(var obj in query)
                        {
                            ML.BecasUsuarios becasUsuarios = new ML.BecasUsuarios();
                            becasUsuarios.Becas = new ML.Becas();
                            becasUsuarios.Usuario = new ML.Usuario();
                            becasUsuarios.Usuario.IdUsuario = obj.IdAlumno;
                            becasUsuarios.Usuario.Nombre = obj.NombreAlumno;
                            becasUsuarios.Becas.IdBeca = obj.IdBecas;
                            becasUsuarios.Becas.Nombre = obj.NombreBecas;

                            result.Objects.Add(becasUsuarios);
                        }
                        result.Correct= true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
    }
}
