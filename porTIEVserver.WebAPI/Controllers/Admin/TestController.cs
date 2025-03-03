using FluentEmail.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using porTIEVserver.WebAPI.Abstractions;

namespace porTIEVserver.WebAPI.Controllers.Admin
{
    [AllowAnonymous]
    public sealed class TestController : ApiController
    {
        private readonly IFluentEmail _fluentEmail;
        public TestController(IMediator mediator, IFluentEmail fluentEmail) : base(mediator)
        {
            _fluentEmail = fluentEmail;
        }
        [HttpGet]
        public async Task<IActionResult> SendTestEmail()
        {
            await _fluentEmail
                .To("ufuktanaci@hotmail.com")
                .Subject("Test mail")
                .Body("<h1>Mail gönderme testi</h1>")
                .SendAsync();

            return NoContent();

        }
    }
}
