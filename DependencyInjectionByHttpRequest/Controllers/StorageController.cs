using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DependencyInjectionByHttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IFileSystemAccess _fileSystemAccess;

        public StorageController(IFileSystemAccess fileSystemAccess)
        {
            _fileSystemAccess = fileSystemAccess;
        }

        [HttpGet]
        public async Task<IActionResult> SaveContent(string content)
        {
            string filename = $"file-{DateTime.UtcNow:yyyyMMddhhmmss}.txt";
            await _fileSystemAccess.WriteOnFile(filename, content);
            return Ok();
        }
    }
}