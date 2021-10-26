using System.IO;
using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest
{
    public interface IFileSystemAccess
    {
        Task<FileSystemSaveResult> WriteOnFile(string fileName, string content);
    }

    public class FakeFileSystemAccess : IFileSystemAccess
    {
        public Task<FileSystemSaveResult> WriteOnFile(string fileName, string content)
        {
            return Task.FromResult(new FileSystemSaveResult("Used mock File System access"));
        }
    }

    public class FileSystemSaveResult
    {
        public FileSystemSaveResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class RealFileSystemAccess : IFileSystemAccess
    {
        public Task<FileSystemSaveResult> WriteOnFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
            return Task.FromResult(new FileSystemSaveResult("Used real File System access"));
        }
    }
}