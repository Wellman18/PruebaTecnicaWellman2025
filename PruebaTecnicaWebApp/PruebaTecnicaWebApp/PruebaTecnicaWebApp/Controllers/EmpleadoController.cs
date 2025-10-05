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

        public async Task<IActionResult> Index(string buscar)
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

                if (!String.IsNullOrEmpty(buscar))
                {
                    listaEmpleado = listaEmpleado.Where(x => x.NumeroIdentificacion!.Contains(buscar));
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
        public async Task<IActionResult> Create([FromBody] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "CrearEmpleado")?.value;

                var response = await httpClient.PostAsJsonAsync(url, empleado);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }


            }
            return Json(new { success = false, message = "Error al crear usuario" });
        }


        public async Task<IActionResult> Edit(int? id)
        {
            modelEmpleado = new();

            var url =   configuration.GetSection("CustomValues")
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

                var listadoEmpleados = JsonSerializer.Deserialize<List<Models.Empleado>>(content, options);

                var listadoTipoIdentificacion = JsonSerializer.Deserialize<List<Models.TipoIdentificacion>>(contentIdentificacion, options);

                foreach (var item in listadoEmpleados)
                {
                    item.Identificacion = listadoTipoIdentificacion.FirstOrDefault(t => t.IdTipoIdentificacion == item.IdTipoIdentificacion);
                }

                modelEmpleado = listadoEmpleados.FirstOrDefault(x => x.IdEmpleado == id);

                ViewBag.TiposIdentificacion = new SelectList(listadoTipoIdentificacion, "IdTipoIdentificacion", "Descripcion",modelEmpleado.Identificacion.Descripcion);
            }

            if (modelEmpleado == null)
            {
                return NotFound();
            }
            return View(modelEmpleado);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[FromBody] Empleado empleado)
        {
            empleado.IdEmpleado = id;

            if (ModelState.IsValid)
            {
                var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "ModificarEmpleado")?.value;

                var response = await httpClient.PostAsJsonAsync(url, empleado);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false, message = "Error al editar empleado" });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            modelEmpleado = new();

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

                var listadoEmpleados = JsonSerializer.Deserialize<List<Models.Empleado>>(content, options);

                var listadoTipoIdentificacion = JsonSerializer.Deserialize<List<Models.TipoIdentificacion>>(contentIdentificacion, options);

                foreach (var item in listadoEmpleados)
                {
                    item.Identificacion = listadoTipoIdentificacion.FirstOrDefault(t => t.IdTipoIdentificacion == item.IdTipoIdentificacion);
                }

                modelEmpleado = listadoEmpleados.FirstOrDefault(x => x.IdEmpleado == id);
            }

            if (modelEmpleado == null)
            {
                return NotFound();
            }
            return View(modelEmpleado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( [FromBody] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var url =   configuration.GetSection("CustomValues")
                            .Get<List<CustomValues>>()
                            .FirstOrDefault(x => x.key == "EliminarEmpleado")?.value;

                var response = await httpClient.PostAsJsonAsync(url, empleado);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false, message = "Error al editar usuario" });

            //if (respuestaExitosa == true)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    return Problem("Entity set 'ConnectionManagerDbContext.Usuarios'  is null.");
            //}

            //if (_context.Usuarios == null)
            //{
            //    return Problem("Entity set 'ConnectionManagerDbContext.Usuarios'  is null.");
            //}
            //var usuario = await _context.Usuarios.FindAsync(id);

            /*usuario != null*/
            //if (id == _usuario.Id)
            //{
            //    //_context.Usuarios.Remove(usuario);

            //    var url = _configuration.GetSection("CustomValues")
            //                .Get<List<CustomValues>>()
            //                .FirstOrDefault(x => x.key == "EliminarUsuario")?.value;

            //    var response = await httpClient.PostAsJsonAsync(url, _usuario);
            //}

            //await _context.SaveChangesAsync();


            //var url = _configuration.GetSection("CustomValues")
            //            .Get<List<CustomValues>>()
            //            .FirstOrDefault(x => x.key == "EliminarUsuario")?.value;

            //var response = await httpClient.PostAsJsonAsync(url, usuario);

            //return RedirectToAction(nameof(Index));
        }
    }
}
