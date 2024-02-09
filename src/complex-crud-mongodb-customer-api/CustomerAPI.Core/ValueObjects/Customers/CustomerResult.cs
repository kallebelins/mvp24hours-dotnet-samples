﻿using AutoMapper;
using CustomerAPI.Core.Entities;
using Mvp24Hours.Core.Contract.Mappings;
using System;

namespace CustomerAPI.Core.ValueObjects.Customers
{
    public class CustomerResult : IMapFrom
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerResult>();
        }
    }
}
