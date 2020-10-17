using System;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RPrestamos.Entidades;
using RPrestamos.DAL;
using System.Collections.Generic;

namespace RPrestamos.BLL
{
    public class PersonasBLL
    {

        //Boton Guardar//
        public static bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }



        private static bool Insertar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Personas.Add(personas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        private static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var personas = contexto.Personas.Find(id);

                if (personas != null)
                {
                    contexto.Personas.Remove(personas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas personas = new Personas();

            try
            {
                personas = contexto.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return personas;
        }


        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {

                encontrado = contexto.Personas.Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }



    }



}