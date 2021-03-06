﻿using EShop.Domain.Core.Events;
using MediatR;
using System;

namespace EShop.Domain.Core.Notifications
{
    public class DomainNotification : Event, INotification
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
