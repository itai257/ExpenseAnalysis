using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ExpenseAnalysis.Common.Api.Dtos;

namespace ExpenseAnalysis.UI.ViewModels;

public class ExpenseTypeViewModel : IHaveMapping
{
    [DisplayName("שם")]
    [Required(ErrorMessage = "שם הוא שדה חובה")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "שם חייב להיות בין 2 ל-100 תווים")]
    public string Name { get; set; } = string.Empty;

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<ExpenseTypeClassDto, ExpenseTypeViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        profile.CreateMap<ExpenseTypeViewModel, ExpenseTypeClassDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
} 