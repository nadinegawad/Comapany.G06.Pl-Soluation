namespace Comapany.G02.Pl.Helper
{
    public class DocumentSetting
    {
        public static string Upload(IFormFile file, string fileName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files\\{fileName}");
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            string FilePath=Path.Combine(FolderPath,fileName);
            var FileStream =new FileStream(FilePath,FileMode.Create);
            file.CopyTo(FileStream);
            return fileName;
        }

        public static void Delete(string fileName, string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files\\{FolderName},{fileName}");
           if (File.Exists(FilePath))
           File.Delete(FilePath);
       
        }
    }
}
