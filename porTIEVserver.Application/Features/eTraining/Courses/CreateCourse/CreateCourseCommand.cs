using MediatR;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Courses.CreateCourse
{
    public sealed record CreateCourseCommand(


        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
