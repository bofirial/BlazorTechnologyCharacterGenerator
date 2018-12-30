﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTechnologyCharacterPropertyGenerators(this IServiceCollection services)
        {
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterNameTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterClassTechnologyCharacterPropertyGenerator>();

            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(2, t => t.HitPoints, h => (ushort)(h * 50)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(3, t => t.Strength, h => (ushort)(h / 2)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(4, t => t.Agility, h => (ushort)(h / 2)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(5, t => t.Intelligence, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(6, t => t.Charisma, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(7, t => t.Wisdom, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(8, t => t.Luck, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(9, t => t.Constitution, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(10, t => t.Perception, h => h));

            return services;
        }
    }
}