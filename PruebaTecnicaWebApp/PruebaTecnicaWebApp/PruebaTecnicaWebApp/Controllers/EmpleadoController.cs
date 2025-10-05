using Microsoft.AspNetCore.Mvc;
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
        Empleado modelEmpleado;

        public EmpleadoController(IConfiguration _configuration, HttpClient _httpClient)
        {
            configuration= _configuration; //ObtenerEmpleado
            httpClient = _httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = configuration.GetSection("CustomValues")
                        .Get<List<CustomValues>>()
                        .FirstOrDefault(x => x.key == "ObtenerEmpleado")?.value;

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                listaEmpleado = JsonSerializer.Deserialize<List<Models.Empleado>>(content, options);

                return listaEmpleado != null
                                        ? View(listaEmpleado)
                                        : Problem("No se pudieron obtener los datos de los empleados.");

            }

            return Problem("Error al obtener datos de la API.");
        }


        public IActionResult Create()
        {
            return View();
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
