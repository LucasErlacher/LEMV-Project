using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;

namespace LEMV.Application.Services
{
    public class PaperAppService : IPaperAppService
    {
        private readonly IMapper _mapper;
        private readonly IPaperService _service;

        public PaperAppService(IMapper mapper, IPaperService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public PaperViewModel CreatePaper(PaperViewModel paper)
        {
            var entity = _mapper.Map<Paper>(paper);

            entity = _service.Create(entity);

            return _mapper.Map<PaperViewModel>(entity);
        }

        public PaperViewModel UpdatePaper(PaperViewModel paper)
        {
            var entity = _mapper.Map<Paper>(paper);

            entity = _service.Update(entity);

            return _mapper.Map<PaperViewModel>(entity);
        }

        public void DeletePaper(int id)
        {
            _service.Delete(id);
        }
    }
}