using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Classrooms.CreateClassroom
{
    public sealed record CreateClassroomCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
