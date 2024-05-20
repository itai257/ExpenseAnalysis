using ExpenseAnalysis.Common.Model;
using ExpenseAnalysis.Common.Model.Visa;
using ExpenseAnalysis.UI.Components;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using AutoMapper;

namespace ExpenseAnalysis.UI.ViewModels;

public class VisaReportViewModel : IHaveMapping
{
    [DisplayName("חודש")]
    public string Month { get; set; }

    [DisplayName("שנה")]
    public string Year { get; set; }

    [DisplayName("4 ספרות אחרונות")]
    public string LastDigits { get; set; }

    [DisplayName("סוג כרטיס")]
    public string CardType { get; set; }

    public List<VisaRecordViewModel> Records { get; set; }

    [DisplayName("סהכ חיוב")]
    public string TotalCharge { get; set; }

    public string Title => $"{CardType} - {LastDigits}";

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<VisaReport, VisaReportViewModel>()
            .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Month))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.LastDigits, opt => opt.MapFrom(src => src.LastDigits))
            .ForMember(dest => dest.CardType, opt => opt.MapFrom(src => src.CardType.ToString()))
            .ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records))
            .ForMember(dest => dest.TotalCharge, opt => opt.MapFrom(src => src.TotalCharge.ToString("N")));
    }
}

public class VisaRecordViewModel : IHaveMapping
{
    public List<string> Headers => new()
    {
        GetType().GetDisplayName(nameof(Date)),
        GetType().GetDisplayName(nameof(BusinessPlaceName)),
        GetType().GetDisplayName(nameof(DealAmount)),
        GetType().GetDisplayName(nameof(ChargeCost)),
        GetType().GetDisplayName(nameof(DealKind)),
        GetType().GetDisplayName(nameof(Category)),
        GetType().GetDisplayName(nameof(Notes))
    };

    [DisplayName("תאריך")]
    public string Date { get; set; }

    [DisplayName("בית עסק")]
    public string BusinessPlaceName { get; set; }

    [DisplayName("סכום עסקה")]
    public MoneyViewModel DealAmount { get; set; }

    [DisplayName("סכום חיוב")]
    public MoneyViewModel ChargeCost { get; set; }

    [DisplayName("סוג עסקה")]
    public string DealKind { get; set; }

    [DisplayName("קטגוריה")]
    public string Category { get; set; }

    [DisplayName("הערות")]
    public string Notes { get; set; }

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<VisaRecord, VisaRecordViewModel>()
            .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date.HasValue == false ? "" : src.Date.Value.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.BusinessPlaceName, opt => opt.MapFrom(src => src.BusinessPlaceName))
            .ForMember(dest => dest.DealAmount, opt => opt.MapFrom(src => new MoneyViewModel(src.DealAmount)))
            .ForMember(dest => dest.ChargeCost, opt => opt.MapFrom(src => new MoneyViewModel(src.ChargeCost)))
            .ForMember(dest => dest.DealKind, opt => opt.MapFrom(src => src.DealKind))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
    }
}