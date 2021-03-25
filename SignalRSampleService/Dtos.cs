namespace SignalRSampleService.Dtos
{
    /// <summary>
    /// Record DTO that repreents basic details about project.
    /// </summary>
    public record ProjectDetailDto(string Name);

    /// <summary>
    /// Record DTO for updating project detail information.
    /// </summary>
    public record ProjectDetailUpdateDto(string Name);

    /// <summary>
    /// Record DTO that repreents company item.
    /// </summary>
    public record CompanyItemDto(string Name, string Address, string City, string State, string Postalcode);
}
