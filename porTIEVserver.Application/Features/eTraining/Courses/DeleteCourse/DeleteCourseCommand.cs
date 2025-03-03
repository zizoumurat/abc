using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Courses.DeleteCourse
{
    public sealed record DeleteCourseCommand(
        int Ref
        ) : IRequest<Result<string>>;
}
