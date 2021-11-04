using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest
{
    public interface IFileSystemAccess
    {
        Task<FileSystemSaveResult> WriteOnFile(string fileName, string content);
    }
}