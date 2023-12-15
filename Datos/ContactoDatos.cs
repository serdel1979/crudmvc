using CRUD.Models;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace CRUD.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar()
        {
            var contactos = new List<ContactoModel>();

            var conn = new Conexion();

            using (var conexion = new NpgsqlConnection(conn.getCadenaSQL()))
            {
                conexion.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("listar_usuarios", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contactos.Add(new ContactoModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Email = dr["Email"].ToString()
                        });
                    }
                }
            }
            return contactos;
        }



        public ContactoModel GetContacto(int Id)
        {
            var contacto = new ContactoModel();

            var conn = new Conexion();

            using (var conexion = new NpgsqlConnection(conn.getCadenaSQL()))
            {
                conexion.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("obtener_usuario", conexion);
                cmd.Parameters.AddWithValue("p_id", Id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contacto.Id = Convert.ToInt32(dr["Id"]);
                        contacto.Nombre = dr["Nombre"].ToString();
                        contacto.Apellido = dr["Apellido"].ToString();
                        contacto.Email = dr["Email"].ToString();
                    }
                }
            }
            return contacto;
        }

       


        public bool Guardar(ContactoModel contacto)
        {
            bool resp;
            try
            {
                var conn = new Conexion();

                using (var conexion = new NpgsqlConnection(conn.getCadenaSQL()))
                {
                    conexion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("agregar_usuario", conexion);
                    cmd.Parameters.AddWithValue("p_Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("p_Apellido", contacto.Apellido);
                    cmd.Parameters.AddWithValue("p_Email", contacto.Email);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    resp = true;
                }
            }
            catch (Exception e)
            {
                resp = false;
            }
            return resp;
        }

        public bool Editar_contacto(ContactoModel contact)
        {
            bool resp;
            try
            {

                var conn = new Conexion();

                using (var conexion = new NpgsqlConnection(conn.getCadenaSQL()))
                {

                    conexion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("editar_usuario", conexion);
                    cmd.Parameters.AddWithValue("p_id", contact.Id);
                    cmd.Parameters.AddWithValue("p_nombre", contact.Nombre);
                    cmd.Parameters.AddWithValue("p_Apellido", contact.Apellido);
                    cmd.Parameters.AddWithValue("p_email", contact.Email);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    resp = true;

                }

            }
            catch (Exception e)
            {
                resp = false;
            }
            return resp;
        }


    }
}
