namespace Collections.Web.Interfaces;

public interface IDataExportService
{
    public Task<MemoryStream> ExportCollectionToCsv(int collectionId);
}