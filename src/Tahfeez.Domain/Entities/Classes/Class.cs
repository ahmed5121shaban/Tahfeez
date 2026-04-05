using System;
using System.Collections.Generic;
using System.Text;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Domain.Entities.Classes
{
    public class Class : AuditableEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Mode { get; set; }
    }
}
