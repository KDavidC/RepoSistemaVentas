using System.Data;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
namespace DL_Sistema_Ventas;

public class DL_ConexionBaseDatos
{
    private readonly IConfiguration _configuracion;
    public string conexionSql;

    public DL_ConexionBaseDatos(IConfiguration configuracion)
    {
        _configuracion = configuracion;
        conexionSql = _configuracion["AppSettings:ConexionMySql"];
    }

    public DataTable GetInformacionMySql(string nombreSp, List<MySqlParameter> lstParametros)
    {
        DataTable tablaGlobal = new();
        string ConexionPrueba = conexionSql;
        try
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionSql))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(nombreSp,conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (lstParametros != null)
                    {
                        foreach (var parametros in lstParametros)
                        {
                            comando.Parameters.Add(parametros);
                        }
                    }
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tablaGlobal);
                    }
                } 
            }
        }
        catch (Exception ex)
        {

        }
        return tablaGlobal;
    }
}

