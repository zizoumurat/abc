using GenericRepository;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Repositories.eTraining;
using porTIEVserver.Infrastructure.Context;

namespace porTIEVserver.Infrastructure.Repositories.eTraining
{
    internal sealed class ParticipantRepository : Repository<Participant, FirmDbContext>, IParticipantRepository
    {
        public ParticipantRepository(FirmDbContext context) : base(context)
        {
        }
    }
}
