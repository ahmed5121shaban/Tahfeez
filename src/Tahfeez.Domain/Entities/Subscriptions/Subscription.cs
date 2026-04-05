using System;
using System.Collections.Generic;
using System.Text;
using Tahfeez.Domain.Entities.Users;
using Tahfeez.SharedKernal.Common;

namespace Tahfeez.Domain.Entities.Subscriptions
{
    public class Subscription: AuditableEntity
    {
        public string Type { get; set; }
        public string Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
