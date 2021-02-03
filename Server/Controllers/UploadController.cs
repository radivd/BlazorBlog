using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace BlazorBlog.Server.Controllers
{
    [ApiController]
    [Route("api/upload")]
    [Authorize]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folder = Path.Combine("content", "images");
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), folder);
                if (file.Length <= 0) 
                    return BadRequest();
                
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(savePath, fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    file.CopyTo(stream);
                    
                return Ok(Path.Combine(folder, fileName));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}