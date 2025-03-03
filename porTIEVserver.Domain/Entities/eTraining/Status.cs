using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using porTIEVserver.Domain.Abstractions;

namespace porTIEVserver.Domain.Entities.eTraining
{
    public sealed class Status : Entity
    {
        public string   Code        { get; set; } = string.Empty;
        public string   Name        { get; set; } = string.Empty;
        public string   Desc        { get; set; } = string.Empty;

    }
}
