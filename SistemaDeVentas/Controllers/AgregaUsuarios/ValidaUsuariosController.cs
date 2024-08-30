using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ML_Sistema_Ventas;
using BL_Sistema_Ventas;
using System.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaDeVentas.Controllers.AgregaUsuarios
{
    public class ValidaUsuariosController : Controller
    {
        BL_ValidaUsuarios blUsuarios;

        public ValidaUsuariosController(IConfiguration configuracion)
        {
            blUsuarios = new(configuracion);
        }

        [HttpPost]
        public ActionResult ValidaUsuariosRegistrado([FromBody] DatosRegistroModel datosUsuario)
        {
            string mensajeError = string.Empty;
            DataTable tablaUsuario = new();
            try
            {
                tablaUsuario = blUsuarios.ObtieneUsuarioRegistrado(datosUsuario);
                if (tablaUsuario.Rows.Count > 0)
                {
                    return View("DatoEncontrado");
                }
                else
                {
                    return Json("NoDatos");
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
            return View();
        }
        public ActionResult NuevoUsuario()
        {
            DatosRegistroModel model = new();
            return View("~/Views/AgregaUsuarios/NuevoUsuario.cshtml");
        }
    }
}

