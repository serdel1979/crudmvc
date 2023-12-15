

namespace CRUD.Datos
{
    public class Conexion
    {

        private string cadenaSQL = "";

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }


        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
