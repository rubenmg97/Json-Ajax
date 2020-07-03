using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiDev.Data.Persona;
using TiDev.Entity.Persona;

namespace TiDev.Bussines.Persona
{
    public class BusPersona
    {
        DatPersona data = new DatPersona();
        public List<EntPersona> Obtener()
        {
            List<EntPersona> ls = new List<EntPersona>();
            DataTable tabla = new DataTable();
            tabla = data.Obtener();
            foreach (DataRow fila in tabla.Rows)
            {
                EntPersona persona = new EntPersona();
                persona.Id = Convert.ToInt32(fila["Id"]);
                persona.Nombre = fila["Nombre"].ToString();
                persona.Paterno = fila["Paterno"].ToString();
                persona.Materno = fila["Materno"].ToString();
                persona.Sexo = Convert.ToBoolean(fila["Sexo"]);
                persona.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
                persona.Alta = Convert.ToDateTime(fila["FechaAlta"]);
                persona.Edad = Convert.ToInt32(fila["Edad"]);

                ls.Add(persona);
            }
            return ls;
        }

        public EntPersona Obtener(int id)
        {
            DataRow fila = data.Obtener(id);
            EntPersona persona = new EntPersona();
            persona.Id = Convert.ToInt32(fila["Id"]);
            persona.Nombre = fila["Nombre"].ToString();
            persona.Paterno = fila["Paterno"].ToString();
            persona.Materno = fila["Materno"].ToString();
            persona.Sexo = Convert.ToBoolean(fila["Sexo"]);
            persona.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
            persona.Alta = Convert.ToDateTime(fila["FechaAlta"]);
            persona.Edad = Convert.ToInt32(fila["Edad"]);
            return persona;
        }

        public List<EntPersona> Obtener(String nombre)
        {
            List<EntPersona> ls = new List<EntPersona>();
            DataTable tabla = new DataTable();
            tabla = data.Obtener(nombre);
            foreach (DataRow fila in tabla.Rows)
            {
                EntPersona persona = new EntPersona();
                persona.Id = Convert.ToInt32(fila["Id"]);
                persona.Nombre = fila["Nombre"].ToString();
                persona.Paterno = fila["Paterno"].ToString();
                persona.Materno = fila["Materno"].ToString();
                persona.Sexo = Convert.ToBoolean(fila["Sexo"]);
                persona.Nacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
                persona.Alta = Convert.ToDateTime(fila["FechaAlta"]);
                persona.Edad = Convert.ToInt32(fila["Edad"]);

                ls.Add(persona);
            }
            return ls;
        }

        public void Delete(int id)
        {
            int filasAfectadas = data.Delete(id);
            if (filasAfectadas != 1)
            {
                throw new ApplicationException("Error al Eliminar Persona");
            }
        }

        public void Edit(EntPersona p)
        {
            int filasAfectadas = data.Edit(p.Id, p.Nombre, p.Paterno, p.Materno, p.Nacimiento, p.Sexo);
            if (filasAfectadas != 1)
            {
                throw new ApplicationException("Error al Editar Persona");
            }
        }

        public void Create(EntPersona p)
        {
            //if (data.Obtener(p.Nombre, p.Paterno, p.Materno))
            //{
            int filasAfectadas = data.Create(p.Nombre, p.Paterno, p.Materno, p.Nacimiento, p.Sexo);
            if (filasAfectadas != 1)
            {
                throw new ApplicationException("Error al Crear Persona");
            }
            //}
            //else
            //{
            //throw new ApplicationException("Error Persona Existente");
            //}
        }
    }
}
