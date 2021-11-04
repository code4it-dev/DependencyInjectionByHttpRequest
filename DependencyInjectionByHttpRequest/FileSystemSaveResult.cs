namespace DependencyInjectionByHttpRequest
{
    public class FileSystemSaveResult
    {
        public FileSystemSaveResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}