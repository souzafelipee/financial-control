﻿using AutoMapper;
using FinancialControl.Application.UseCases.Transaction.Requests;
using FinancialControl.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using System;

namespace FinancialControl.Infra.CrossCutting.Mappers
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<RegisterTransactionRequest, TransactionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.TransactionDescription))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.TransactionValue))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<TransactionModel, TransactionDataModel>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionType))
                .ForMember(dest => dest.TransactionType, opt => opt.Ignore());
        }
    }
}
