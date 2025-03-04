using porTIEVserver.Domain.Enums;

namespace porTIEVserver.Domain.Dtos;

public sealed record ContactFilterDto(string? Code, string? FirstName, string? LastName, string? Phone, string? CityCode, ContactTypeEnum? ContactType);
public sealed record ContactListDto
{
    public int Ref { get; set; }
    public required ContactTypeEnum ContactType { get; init; }
    public string Code { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string InchargeRef { get; init; } = string.Empty;
    public string FullAddress { get; init; } = string.Empty;
    public string CityRef { get; init; } = string.Empty;
    public string CountryRef { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Mobile { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}
