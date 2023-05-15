using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext _context = new VentaRealContext())
                {
                    var list = _context.Clientes.ToList();
                    respuesta.Exito = 1;
                    respuesta.Data = list;
                }

            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);

        }

        [HttpPost]
        public IActionResult Add(ClienteRequest Data)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext _context = new VentaRealContext())
                {
                    Cliente DBData = new Cliente();

                    DBData.Nombre = Data.Nombre;
                    _context.Clientes.Add(DBData);
                    _context.SaveChanges();

                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest Data)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext _context = new VentaRealContext())
                {
                    Cliente DBData = _context.Clientes.Find(Data.Id);

                    DBData.Nombre = Data.Nombre;
                    _context.Entry(DBData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext _context = new VentaRealContext())
                {
                    Cliente DBData = _context.Clientes.Find(id);
                    
                    _context.Remove(id);
                    _context.SaveChanges();

                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
