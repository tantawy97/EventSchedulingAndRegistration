namespace EventSchedulingAndRegistration.Application.Common
{
    public class DefaultResponseDTO
    {
        public string message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public static DefaultResponseDTO ErrorResponse(string message = "An Error Has Occurred") => new() { message = message, Status = false };
        public static DefaultResponseDTO SuccessResponse(string message = "Success") => new() { message = message };
    }
}