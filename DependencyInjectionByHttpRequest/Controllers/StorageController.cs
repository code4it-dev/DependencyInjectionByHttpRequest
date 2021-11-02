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

        [HttpPost]
        public async Task<IActionResult> SaveContent([FromBody] FileInfo content)
        {
            string filename = $"file-{Guid.NewGuid()}.txt";
            var saveResult = await _fileSystemAccess.WriteOnFile(filename, content.Content);
            return Ok(saveResult);
        }

        public class FileInfo
        {
            public string Content { get; set; }
        }
    }
}