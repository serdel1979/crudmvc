using CRUD.Models;
using Microsoft.Data.SqlClient;

namespace CRUD.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var contactos = new List<ContactoModel>();

            var conn = new Conexion();

            using(var conexion = new SqlConnection(conn.getCadenaSQL())){

                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_usuarios",conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contactos.Add(new ContactoModel { 
                            
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

            using (var conexion = new SqlConnection(conn.getCadenaSQL()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtener_usuario", conexion);
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

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("agregar_usuario", conexion);
                    cmd.Parameters.AddWithValue("p_Nombre", contacto.Nombre);
                    cmd.Parameters.AddWithValue("p_Apellido", contacto.Apellido);
                    cmd.Parameters.AddWithValue("p_Email", contacto.Email);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    resp = true;

                }

            }
            catch(Exception e)
            {
                resp = false;
            }
            return resp;
        }




        public bool Borrar(int Id)
        {
            bool resp;
            try
            {

                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_usuario", conexion);
                    cmd.Parameters.AddWithValue("p_id", Id);
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

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("editar_usuario", conexion);
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
