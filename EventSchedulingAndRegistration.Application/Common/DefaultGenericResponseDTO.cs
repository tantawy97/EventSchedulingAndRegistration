namespace EventSchedulingAndRegistration.Application.Common
{
    public class DefaultGenericResponseDTO<T> : DefaultResponseDTO
    {
        public T? Body { get; set; }
        public long? TotalCount { get; set; }

        public static DefaultGenericResponseDTO<T> SuccessResponse(T? Body, long? TotalCount = null, string Message = "Success") => new()
        {
            Body = Body,
            TotalCount = TotalCount,
            message = Message
        };   
        public static DefaultGenericResponseDTO<T> ErrorResponse(T? Body, string Message = "Error") => new()
        {
            Body = Body,
            Status = false,
            message = Message
        };
    }
}