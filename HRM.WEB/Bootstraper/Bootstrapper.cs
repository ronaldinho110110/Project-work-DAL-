﻿using AutoMapper;
using HRM.Web.DependencyInjection;

namespace HRM.Web.Bootstraper
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            DependencyResolverConfig.RegisterType(
                new WebTypeResolver()
            );

            Mapper.Initialize(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            //Mapper.AssertConfigurationIsValid();

        }
    }
}