using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaWebApp.Models;
using System.Text.Json;

namespace PruebaTecnicaWebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        IConfiguration configuration;
        private readonly HttpClient httpClient;
        IEnumerable<Empleado> listaEmpleado = Enumerable.Empty<Empleado>();
        IEnumerable<TipoIdentificacion> listaTipoIdentificacion = Enumerable.Empty<TipoIdentificacion>();
        Empleado modelEmpleado;

        public EmpleadoController(IConfiguration _configuration, HttpClient _httpClient)
        {
            configuration= _configuration; 
            httpClient = _httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "ObtenerEmpleado")?.value;

            var urlTipoIdentificacion = configuration.GetSection("CustomValues")
                                    .Get<List<CustomValues>>()
                                    .FirstOrDefault(x => x.key == "ObtenerTipoIdentificacion")?.value;

            var response = await httpClient.GetAsync(url);

            var responseIdentificacion = await httpClient.GetAsync(urlTipoIdentificacion);

            if (response.IsSuccessStatusCode && responseIdentificacion.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var contentIdentificacion = await responseIdentificacion.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                listaEmpleado = JsonSerializer.Deserialize<List<Models.Empleado>>(content, options);

                listaTipoIdentificacion = JsonSerializer.Deserialize<List<Models.TipoIdentificacion>>(contentIdentificacion, options);

                foreach (var item in listaEmpleado)
                {
                    item.Identificacion = listaTipoIdentificacion.FirstOrDefault(t => t.IdTipoIdentificacion == item.IdTipoIdentificacion);
 


                }


                return listaEmpleado != null
                                        ? View(listaEmpleado)
                                        : Problem("No se pudieron obtener los datos de los empleados.");

            }

            return Problem("Error al obtener datos de la API.");
        }


        public async Task<IActionResult> Create()
        {
            var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "ObtenerTipoIdentificacion")?.value;

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                listaTipoIdentificacion = JsonSerializer.Deserialize<List<Models.TipoIdentificacion>>(content, options);
            }

            ViewBag.TiposIdentificacion = new SelectList(listaTipoIdentificacion, "IdTipoIdentificacion", "Descripcion");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Nombre,Correo")]*/[FromBody] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "CrearEmpleado")?.value;

                var response = await httpClient.PostAsJsonAsync(url, empleado);

                if (response.IsSuccessStatusCode)
                {
                    //var content = await response.Content.ReadAsStringAsync();

                    //var options = new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //};

                    //listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(content, options);

                    //return listaUsuarios != null
                    //                        ? View(listaUsuarios)
                    //                        : Problem("No se pudieron deserializar los usuarios.");

                    //_context.Add(usuario);
                    //await _context.SaveChangesAsync();

                    //return RedirectToAction(nameof(Index));

                    return Json(new { success = true });
                }


            }
            //return View(usuario);
            return Json(new { success = false, message = "Error al crear usuario" });
        }
    }
}
