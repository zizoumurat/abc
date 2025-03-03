﻿using MediatR;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using TS.Result;

namespace porTIEVserver.Application.Features.eTraining.Partners.UpdatePartner
{
    public sealed record UpdatePartnerCommand(

        int Ref,
        string Code,
        string Name,
        string Desc

        ) : IRequest<Result<string>>;
}
