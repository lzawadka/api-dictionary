using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Interfaces;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.Dto;
using api_dictionary.Domain.Entities;
using api_dictionary.Domain.Event;
using MapsterMapper;

namespace api_dictionary.Application.Cities.Commands.Create
{
    public class CreateCityCommand : IRequestWrapper<CityDto>
    {
        public string Name { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandlerWrapper<CreateCityCommand, CityDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = new City
            {
                Name = request.Name
            };

            entity.DomainEvents.Add(new CityCreatedEvent(entity));

            await _context.Cities.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CityDto>(entity));
        }
    }
}
