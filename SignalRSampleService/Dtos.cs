namespace SignalRSampleService.Dtos
{
    /// <summary>
    /// Record DTO that repreents basic details about project.
    /// </summary>
    public record ProjectDetail(string name);

    /// <summary>
    /// Record DTO for updating project detail information.
    /// </summary>
    public record ProjectDetailUpdate(string name);

    /// <summary>
    /// Record DTO that repreents company item.
    /// </summary>
    public record CompanyItemDto(string name, string address, string city, string state, string postalcode);
}
