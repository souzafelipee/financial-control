using AutoMapper;
using FinancialControl.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using System;

namespace FinancialControl.Infra.CrossCutting.Mappers
{
    public class AccountBalanceProfile : Profile
    {
        public AccountBalanceProfile()
        {
            CreateMap<AccountBalanceDataModel, AccountBalanceModel>()
                .ForMember(dest => dest.BalanceDate, opt => opt.MapFrom(src => src.UpdatedAt));

            CreateMap<AccountBalanceModel, AccountBalanceDataModel>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.BalanceDate));
        }
    }
}
