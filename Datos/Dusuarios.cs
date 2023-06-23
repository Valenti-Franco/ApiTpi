using System.Data.SqlClient;
using System.Data;
using TiendaApi.Conexion;
using TiendaApi.Modelo;

namespace TiendaApi.Datos
{
    public class Dusuarios
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<Musuarios>> Mostrarproductos()
        {
            var lista = new List<Musuarios>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var Musuarios = new Musuarios();
                            Musuarios.id = (int)item["id"];
                            Musuarios.descripcion = (string)item["descripcion"];
                            Musuarios.precio = (decimal)item["precio"];
                            lista.Add(Musuarios);

                        }
                    }
                }
            }
            return lista;
        }


        public async Task InsertarProductos(Mproductos parametros)

        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
