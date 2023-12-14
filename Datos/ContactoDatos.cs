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
    }
}
