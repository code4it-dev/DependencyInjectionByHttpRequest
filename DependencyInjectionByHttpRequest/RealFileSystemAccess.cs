using System.IO;
using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest
{
    public class RealFileSystemAccess : IFileSystemAccess
    {
        public async Task<FileSystemSaveResult> WriteOnFile(string fileName, string content)
        {
            await File.WriteAllTextAsync(fileName, content);
            return new FileSystemSaveResult("Used real File System access");
        }
    }
}