using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.HR.Presences.CreatePresence
{
    public sealed record CreatePresenceCommand(

        
        string       AppUserId,
        int          FirmRef,  
        string       ScanCode, 
        DateTime     ScanTime, 
        DateTime     SendTime, 
        string       Latitude,
        string       Longitude

        ) : IRequest<Result<string>>;
}

