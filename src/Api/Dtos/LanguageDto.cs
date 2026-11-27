using Domain.Languages;

namespace Api.Dtos;

public record LanguageDto(
    string Code,
    string Name)
{
    public static LanguageDto FromDomainModel(Language language) 
        => new(language.Code.ToString(), 
            language.Name);
}