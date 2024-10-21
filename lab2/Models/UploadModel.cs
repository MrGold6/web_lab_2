using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Models
{
    public class UploadModel : PageModel
    {
        public string Message { get; set; }

        public bool uploadFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", uploadedFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     uploadedFile.CopyToAsync(stream);
                }

                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
