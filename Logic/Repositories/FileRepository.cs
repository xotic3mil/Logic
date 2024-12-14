using Logic.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Logic.Repositories;

public class FileRepository(IFileService fileService) : IFileRepository
{
    private readonly IFileService _fileService = fileService;

    public bool SaveDataToFile<T>(T data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data);
            _fileService.SaveContentToFile(json);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public T GetDataFromFile<T>()
    {

        try
        {
            var json = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(json))
            {
                var data = JsonSerializer.Deserialize<T>(json)!;
                return data;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return default!;
        }

        return default!;
    }

}
