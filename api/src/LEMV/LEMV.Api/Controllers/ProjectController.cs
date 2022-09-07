using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectAppService _projectApp;

        public ProjectController(INotificator notificator, IProjectAppService projectApp) : base(notificator)
        {
            _projectApp = projectApp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_projectApp.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var teste = _projectApp.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(ProjectSaveViewModel news)
        {
            ProjectViewModel result = _projectApp.CreateProject(news);

            return CustomResponse(result);
        }

        [HttpPut()]
        public IActionResult PutAsync(ProjectSaveViewModel news)
        {
            ProjectViewModel result = _projectApp.UpdateProject(news);

            return CustomResponse(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _projectApp.DeleteProject(id);

            return CustomResponse(id);
        }
    }
}