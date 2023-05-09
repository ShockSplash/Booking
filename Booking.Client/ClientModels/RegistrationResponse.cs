#nullable enable
namespace BlazorClient.ClientModels
{
    public class RegistrationResponse
    {
        public bool IsSuccess { get; set; }

        public string? Comment { get; set; }
    }
}