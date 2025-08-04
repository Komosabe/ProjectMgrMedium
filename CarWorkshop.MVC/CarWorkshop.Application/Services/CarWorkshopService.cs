using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarworkshopRepository _carworkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(
            ICarworkshopRepository carworkshopRepository,
            IMapper mapper)
        {
            _carworkshopRepository = carworkshopRepository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto dto)
        {
            var entity = _mapper.Map<Domain.Entities.CarWorkshop>(dto);

            entity.EncodeName();

            await _carworkshopRepository.Create(entity);
        }

        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var entities = await _carworkshopRepository.GetAll();
            return _mapper.Map<IEnumerable<CarWorkshopDto>>(entities);
        }

    }
}
