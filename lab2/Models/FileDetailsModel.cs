using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Models
{
    public class FileDetailsModel : PageModel
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }

        public void setFileDetails(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);
            FileName = fileName;
            FileContent = System.IO.File.ReadAllText(filePath);
        }
    }
}
