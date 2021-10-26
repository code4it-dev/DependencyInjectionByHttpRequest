using System.IO;
using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest
{
    public interface IFileSystemAccess
    {
        Task WriteOnFile(string fileName, string content);
    }

    public class FakeFileSystemAccess : IFileSystemAccess
    {

        public Task WriteOnFile(string fileName, string content)
        {
            return Task.CompletedTask;
        }
    }

    public class RealFileSystemAccess : IFileSystemAccess
    {
        public Task WriteOnFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
            return Task.CompletedTask;
        }
    }
}