﻿using ExpenseAnalysis.Common.Model;
using ExpenseAnalysis.Common.Model.Osh;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using AutoMapper;

namespace ExpenseAnalysis.UI.ViewModels;

public class OshReportViewModel : IHaveMapping
{
    public string Title => "עובר ושב";

    [DisplayName("תאריך התחלה")]
    public string StartDate { get; set; }

    [DisplayName("תאריך סוף")]
    public string EndDate { get; set; }

    public List<OshRecordViewModel> Records { get; set; }

    [DisplayName("סהכ חיוב")]
    public double TotalCharge { get; set; }

    [DisplayName("סהכ הכנסה")]
    public double TotalIncome { get; set; }

    [DisplayName("מאזן")]
    public double Difference { get; set; }

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<OshReport, OshReportViewModel>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records))
            .ForMember(dest => dest.TotalCharge, opt => opt.MapFrom(src => src.TotalCharge.ToString("N")))
            .ForMember(dest => dest.TotalIncome, opt => opt.MapFrom(src => src.TotalIncome.ToString("N")))
            .ForMember(dest => dest.Difference, opt => opt.MapFrom(src => src.Difference.ToString("N")));
    }
}

public class OshRecordViewModel : IHaveMapping
{
    [DisplayName("תאריך")]
    public string Date { get; set; }

    [DisplayName("תאריך ערך")]
    public string ValueDate { get; set; }
    
    [DisplayName("תיאור")]
    public string Description { get; set; }

    [DisplayName("אסמכתא")]
    public int ReferenceNumber { get; set; }

    [DisplayName("חובה")]
    public MoneyViewModel Debit { get; set; }

    [DisplayName("זכות")]
    public MoneyViewModel Credit { get; set; }

    [DisplayName("יתרה")]
    public string Balance { get; set; }

    [DisplayName("הערות")]
    public string Notes { get; set; }


    public List<string> Headers => new()
    {
        GetType().GetDisplayName(nameof(Date)),
        GetType().GetDisplayName(nameof(ValueDate)),
        GetType().GetDisplayName(nameof(Description)),
        GetType().GetDisplayName(nameof(ReferenceNumber)),
        GetType().GetDisplayName(nameof(Debit)),
        GetType().GetDisplayName(nameof(Credit)),
        GetType().GetDisplayName(nameof(Balance)),
        GetType().GetDisplayName(nameof(Notes))
    };

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<OshRecord, OshRecordViewModel>()
            .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date.HasValue == false ? "" : src.Date.Value.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.ValueDate,
                opt => opt.MapFrom(src =>
                    src.ValueDate.HasValue == false ? "" : src.ValueDate.Value.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
            .ForMember(dest => dest.Debit, opt => opt.MapFrom(src => new MoneyViewModel(src.Debit)))
            .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => new MoneyViewModel(src.Credit)))
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance.ToString("N")))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
    }
}