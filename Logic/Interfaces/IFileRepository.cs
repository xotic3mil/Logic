namespace Logic.Interfaces
{
    public interface IFileRepository
    {
        T GetDataFromFile<T>();
        bool SaveDataToFile<T>(T data);
    }
}