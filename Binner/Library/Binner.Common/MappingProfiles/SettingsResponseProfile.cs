﻿using AutoMapper;
using Binner.Common.Configuration;
using Binner.Common.IO.Printing;
using Binner.Common.Models.Configuration;
using Binner.Common.Models.Configuration.Integrations;
using Binner.Common.Models.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Binner.Common.MappingProfiles
{
    public class SettingsResponseProfile : Profile
    {
        public SettingsResponseProfile()
        {
            CreateMap<WebHostServiceConfiguration, SettingsResponse>()
                .ForMember(x => x.Binner, options => options.MapFrom(x => x.Integrations.Swarm))
                .ForMember(x => x.Digikey, options => options.MapFrom(x => x.Integrations.Digikey))
                .ForMember(x => x.Mouser, options => options.MapFrom(x => x.Integrations.Mouser))
                .ForMember(x => x.Octopart, options => options.MapFrom(x => x.Integrations.Octopart))
                .ForMember(x => x.Printer, options => options.MapFrom(x => x.PrinterConfiguration))
                .ReverseMap();

            CreateMap<UserIntegrationConfiguration, SettingsResponse>()
                .ForMember(x => x.Binner, options => options.MapFrom(x => new SwarmUserConfiguration
                {
                    Enabled = x.SwarmEnabled,
                }))
                .ForMember(x => x.Digikey, options => options.MapFrom(x => new DigiKeyUserConfiguration
                {
                    Enabled = x.DigiKeyEnabled,
                }))
                .ForMember(x => x.Mouser, options => options.MapFrom(x => new MouserUserConfiguration
                {
                    Enabled = x.MouserEnabled,
                    CartApiKey = x.MouserCartApiKey,
                    OrderApiKey = x.MouserOrderApiKey,
                }))
                .ForMember(x => x.Octopart, options => options.MapFrom(x => new OctopartUserConfiguration
                {
                    Enabled = x.OctopartEnabled,
                    ApiUrl = x.OctopartApiUrl,
                    ApiKey = x.OctopartApiKey
                }))
                .ForMember(x => x.Printer, options => options.Ignore())
                .ReverseMap();

            CreateMap<MouserConfiguration, MouserConfigurationResponse>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.Enabled))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.ApiUrl))
                .ForMember(x => x.OrderApiKey, options => options.MapFrom(x => x.ApiKeys.OrderApiKey))
                .ForMember(x => x.SearchApiKey, options => options.MapFrom(x => x.ApiKeys.SearchApiKey))
                .ForMember(x => x.CartApiKey, options => options.MapFrom(x => x.ApiKeys.CartApiKey))
                .ReverseMap();

            CreateMap<PrinterConfiguration, PrinterSettingsResponse>(MemberList.None)
                .ForMember(x => x.PartLabelName, options => options.MapFrom(x => x.PartLabelName))
                .ForMember(x => x.PartLabelSource, options => options.MapFrom(x => x.PartLabelSource))
                .ForMember(x => x.PrinterName, options => options.MapFrom(x => x.PrinterName))
                // complex mapping situation
                .ForMember(x => x.Lines, options => options.MapFrom(x => new List<LineConfiguration> {
                        x.PartLabelTemplate.Line1,
                        x.PartLabelTemplate.Line2,
                        x.PartLabelTemplate.Line3,
                        x.PartLabelTemplate.Line4
                    })

                )
                .ForMember(x => x.Identifiers, options => options.MapFrom(x => new List<LineConfiguration> {
                        x.PartLabelTemplate.Identifier,
                        x.PartLabelTemplate.Identifier2
                    })
                );

            CreateMap<PrinterSettingsResponse, PrinterConfiguration>(MemberList.None)
                .ForMember(x => x.PartLabelName, options => options.MapFrom(x => x.PartLabelName))
                .ForMember(x => x.PartLabelSource, options => options.MapFrom(x => x.PartLabelSource))
                .ForMember(x => x.PrinterName, options => options.MapFrom(x => x.PrinterName))
                .ForMember(x => x.LabelDefinitions, options => options.Ignore())
                // complex mapping situation
                .ForMember(x => x.PartLabelTemplate, options => options.MapFrom(x => new PartLabelTemplate
                {
                    Line1 = x.Lines.Skip(0).FirstOrDefault(),
                    Line2 = x.Lines.Skip(1).FirstOrDefault(),
                    Line3 = x.Lines.Skip(2).FirstOrDefault(),
                    Line4 = x.Lines.Skip(3).FirstOrDefault(),
                    Identifier = x.Identifiers.Skip(0).FirstOrDefault(),
                    Identifier2 = x.Identifiers.Skip(1).FirstOrDefault()
                })
            );

            CreateMap<SwarmConfiguration, SwarmUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.Enabled))
                .ForMember(x => x.ApiKey, options => options.MapFrom(x => x.ApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.ApiUrl))
                .ReverseMap();
            CreateMap<DigikeyConfiguration, DigiKeyUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.Enabled))
                .ForMember(x => x.ClientId, options => options.MapFrom(x => x.ClientId))
                .ForMember(x => x.ClientSecret, options => options.MapFrom(x => x.ClientSecret))
                .ForMember(x => x.oAuthPostbackUrl, options => options.MapFrom(x => x.oAuthPostbackUrl))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.ApiUrl))
                .ReverseMap();
            CreateMap<MouserConfiguration, MouserUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.Enabled))
                .ForMember(x => x.OrderApiKey, options => options.MapFrom(x => x.ApiKeys.OrderApiKey))
                .ForMember(x => x.CartApiKey, options => options.MapFrom(x => x.ApiKeys.CartApiKey))
                .ForMember(x => x.SearchApiKey, options => options.MapFrom(x => x.ApiKeys.SearchApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.ApiUrl))
                .ReverseMap();
            CreateMap<OctopartConfiguration, OctopartUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.Enabled))
                .ForMember(x => x.ApiKey, options => options.MapFrom(x => x.ApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.ApiUrl))
                .ReverseMap();

            CreateMap<UserIntegrationConfiguration, SwarmUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.SwarmEnabled))
                .ForMember(x => x.ApiKey, options => options.MapFrom(x => x.SwarmApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.SwarmApiUrl))
                .ReverseMap();

            CreateMap<UserIntegrationConfiguration, DigiKeyUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.DigiKeyEnabled))
                .ForMember(x => x.ClientId, options => options.MapFrom(x => x.DigiKeyClientId))
                .ForMember(x => x.ClientSecret, options => options.MapFrom(x => x.DigiKeyClientSecret))
                .ForMember(x => x.oAuthPostbackUrl, options => options.MapFrom(x => x.DigiKeyOAuthPostbackUrl))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.DigiKeyApiUrl))
                .ReverseMap();

            CreateMap<UserIntegrationConfiguration, MouserUserConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.MouserEnabled))
                .ForMember(x => x.CartApiKey, options => options.MapFrom(x => x.MouserCartApiKey))
                .ForMember(x => x.OrderApiKey, options => options.MapFrom(x => x.MouserOrderApiKey))
                .ForMember(x => x.SearchApiKey, options => options.MapFrom(x => x.MouserSearchApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.MouserApiUrl))
                .ReverseMap();

            CreateMap<UserIntegrationConfiguration, OctopartConfiguration>()
                .ForMember(x => x.Enabled, options => options.MapFrom(x => x.OctopartEnabled))
                .ForMember(x => x.ApiKey, options => options.MapFrom(x => x.OctopartApiKey))
                .ForMember(x => x.ApiUrl, options => options.MapFrom(x => x.OctopartApiUrl))
                .ReverseMap();
        }
    }
}