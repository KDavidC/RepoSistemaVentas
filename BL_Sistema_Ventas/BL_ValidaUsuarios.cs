using System.Data;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using DL_Sistema_Ventas;
using ML_Sistema_Ventas;
namespace BL_Sistema_Ventas;

public class BL_ValidaUsuarios
{
    private DL_ConexionBaseDatos conexionMySql;
    public BL_ValidaUsuarios(IConfiguration configuracion)
    {
        conexionMySql = new DL_ConexionBaseDatos(configuracion);
    }
    public DataTable ObtieneUsuarioRegistrado(DatosRegistroModel datosUsuario)
    {
        DataTable tablaBuscaUsuario = new();
        try
        {
            List<MySqlParameter> lstParametros = new List<MySqlParameter>
            {
                new MySqlParameter("CORREO_USUARIO", MySqlDbType.VarChar) { Value = datosUsuario.Correo },
                new MySqlParameter("CONTRASENIA_USUARIO", MySqlDbType.VarChar) { Value =  datosUsuario.Contrasenia }
            };
            tablaBuscaUsuario = conexionMySql.GetInformacionMySql("SP_GET_BUSCA_USUARIO_REG", lstParametros);
        }
        catch (Exception ex)
        {

        }
        return tablaBuscaUsuario;
    }
    
}

