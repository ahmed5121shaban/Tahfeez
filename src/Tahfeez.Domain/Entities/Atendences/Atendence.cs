using System;
using System.Collections.Generic;
using System.Text;
using Tahfeez.Domain.Entities.Users;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Domain.Entities.Atendences
{
    public class Atendence : AuditableEntity
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
