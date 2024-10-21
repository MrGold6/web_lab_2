using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Models
{
    public class ViewFilesModel : PageModel
    {
        public List<string> Files { get; set; }


        public List<string> getListOfFiles()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");
            Files = Directory.GetFiles(filePath).Select(Path.GetFileName).ToList();
            return Files;
        }
    }
}
