namespace TiendaApi.Conexion
{
    public class Conexionbd
    {
        private string conectionString = string.Empty;
        public Conexionbd()
        { 
        var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conectionString = constructor.GetSection("ConnectionStrings:conexionmaestra").Value;
        }
        public string cadenaSQL()
        {
            return conectionString;
        }
    }
    
}
