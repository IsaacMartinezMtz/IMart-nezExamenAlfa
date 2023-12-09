using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext contex = new DL.ExamenAlfaContext())
                {
                    var query = (from alumno in contex.Alumnos
                                 select new
                                 {
                                     IdAlumno = alumno.IdAlumno,
                                     Nombre = alumno.Nombre,
                                     Genero = alumno.Genero,
                                     Edad = alumno.Edad
                                 }).ToList();
                    result.Objects = new List<object>();
                    if(query.Count > 0)
                    {
                        foreach(var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdAlumno;
                            usuario.Nombre = item.Nombre;
                            usuario.Genero = (bool)item.Genero;
                            usuario.Edad = (int)item.Edad;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext context = new DL.ExamenAlfaContext())
                {
                    var query = (from alumno in context.Alumnos
                                 where alumno.IdAlumno == IdAlumno
                                 select new
                                 {
                                     IdAlumno = alumno.IdAlumno,
                                     Nombre = alumno.Nombre,
                                     Genero = alumno.Genero,
                                     Edad = alumno.Edad
                                 });
                    result.Object = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdAlumno;
                            usuario.Nombre = item.Nombre;
                            usuario.Genero = (bool)item.Genero;
                            usuario.Edad = (int)item.Edad;

                            result.Object = usuario;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add( ML.Usuario  usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext context = new DL.ExamenAlfaContext())
                {
                    DL.Alumno add = new DL.Alumno();
                    add.Nombre = usuario.Nombre;
                    add.Genero = usuario.Genero;
                    add.Edad = usuario.Edad;
                    context.Alumnos.Add(add);
                    int filasAfectadas = context.SaveChanges();
                    if(filasAfectadas > 0)
                    {
                        result.Correct= true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext context = new DL.ExamenAlfaContext())
                {
                    var query = (from usuario in context.Alumnos
                                where usuario.IdAlumno == IdUsuario
                                select usuario).SingleOrDefault();
                    if(query != null)
                    {
                        context.Alumnos.Remove(query);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
        public static ML.Result Updtae (ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenAlfaContext context = new DL.ExamenAlfaContext())
                {
                    var query = (from a in context.Alumnos where a.IdAlumno == usuario.IdUsuario select a).SingleOrDefault();
                    if(query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.Genero = usuario.Genero;
                        query.Edad = usuario.Edad;

                        context.SaveChanges() ;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
               
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
    }
}
