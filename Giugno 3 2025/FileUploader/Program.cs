public interface IStorageService
{
    void UploadFile(string file);
}

public class Disk : IStorageService
{
    public void UploadFile(string file)
    {
        Console.WriteLine($"File '{file}' caricato su disco.");
    }
}

public class Memory : IStorageService
{
    public void UploadFile(string file)
    {
        Console.WriteLine($"File '{file}' caricato in memoria.");
    }
}

public class FileUploader
{
    public IStorageService StorageService { get; set; }

    public void Upload(string file)
    {
        if (StorageService == null)
        {
            Console.WriteLine("Servizio di archiviazione non inizializzato.");
            return;
        }

        StorageService.UploadFile(file);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        FileUploader uploader = new FileUploader();
        string fileName;

        Console.WriteLine("Scegli il servizio di archiviazione.");
        Console.WriteLine("[1] Disco\n[2] Memoria");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                uploader.StorageService = new Disk();
                Console.WriteLine("Inserisci il nome del file da caricare:");
                fileName = Console.ReadLine();
                uploader.Upload(fileName);
                break;
            case "2":
                uploader.StorageService = new Memory();
                Console.WriteLine("Inserisci il nome del file da caricare:");
                fileName = Console.ReadLine();
                uploader.Upload(fileName);
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }
    }
}