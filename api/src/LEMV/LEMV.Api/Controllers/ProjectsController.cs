using AutoMapper;
using LEMV.Api.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LEMV.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly ILogger<ProjectViewModel> _logger;
        private readonly IMapper _mapper;

        public ProjectsController(INotificator notificator,
                                  ILogger<ProjectViewModel> logger,
                                  IMapper mapper) : base(notificator)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var p = new ProjectViewModel { Idade = 10 };

            var entity = _mapper.Map<Project>(p);
            var viewModel = _mapper.Map<ProjectViewModel>(entity);


            return new object[] { entity, viewModel };
        }

        [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Está autenticado";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
