using Microsoft.AspNetCore.Mvc;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Web.Models.Responses;
using SalesOnline.Web.Services;

namespace SalesOnline.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly string usuarioApiURLBase;
        private readonly IWebService webService;

        public UsuarioController(IUsuarioService storeService, IWebService webService, IConfiguration configuration)
        {
            this.usuarioService = storeService;
            this.webService = webService;
            this.usuarioApiURLBase = configuration["ApiSettings:UsuarioApiBaseUrl"];
        }
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<UsuarioViewResult>> responseData = webService.GetDataFromApi<List<UsuarioViewResult>>($"{usuarioApiURLBase}GetUsuarios");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BaseResponse<UsuarioViewResult> responseData = webService.GetDataFromApi<UsuarioViewResult>($"{usuarioApiURLBase}GetUsuario?id={id}");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDtoAdd usuarioDtoAdd)
        {
            var apiUrl = $"{usuarioApiURLBase}SaveUsuario";

            usuarioDtoAdd.FechaMod = DateTime.Now;
            usuarioDtoAdd.IdUsuarioMod = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<UsuarioDtoAdd>>(apiUrl, usuarioDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BaseResponse<UsuarioViewResult> responseData = webService.GetDataFromApi<UsuarioViewResult>($"{usuarioApiURLBase}GetUsuario?id={id}");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDtoUpdate usuarioDtoUpdate)
        {
            var apiUrl = $"{usuarioApiURLBase}UpdateUsuario";

            usuarioDtoUpdate.FechaMod = DateTime.Now;
            usuarioDtoUpdate.IdUsuarioMod = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<UsuarioDtoUpdate>>(apiUrl, usuarioDtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                BaseResponse<UsuarioDtoRemove> responseData = webService.GetDataFromApi<UsuarioDtoRemove>($"{usuarioApiURLBase}GetUsuario?id={id}");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioDtoRemove usuarioDtoRemove)
        {
            var apiUrl = $"{usuarioApiURLBase}RemoveUsuario";

            usuarioDtoRemove.FechaMod = DateTime.Now;
            usuarioDtoRemove.IdUsuarioMod = 1;

            try
            {
                var response = webService.PostDataToApi<BaseResponse<UsuarioDtoRemove>>(apiUrl, usuarioDtoRemove);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}

