﻿using AutoMapper;
using CustomerAPI.Core.Entities;
using CustomerAPI.Core.Enums;
using Mvp24Hours.Core.Contract.Mappings;

namespace CustomerAPI.Core.ValueObjects.Contacts
{
    public class ContactUpdate : IMapFrom
    {
        public ContactType Type { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<ContactUpdate, Contact>();
        }
    }
}
