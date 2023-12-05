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
            CreateMap<AccountBalanceDataModel, AccountBalanceModel>();

            CreateMap<AccountBalanceModel, AccountBalanceDataModel>();
        }
    }
}
