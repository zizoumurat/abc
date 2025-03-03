using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.UpdateClassroom
{
    public sealed record UpdateClassroomCommand(

        int Ref,
        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
