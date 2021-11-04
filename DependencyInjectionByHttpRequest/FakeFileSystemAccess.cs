using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest
{
    public class FakeFileSystemAccess : IFileSystemAccess
    {
        public Task<FileSystemSaveResult> WriteOnFile(string fileName, string content)
        {
            return Task.FromResult(new FileSystemSaveResult("Used mock File System access"));
        }
    }
}