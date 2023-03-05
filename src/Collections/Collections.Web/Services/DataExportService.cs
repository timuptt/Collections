using System.Globalization;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using CsvHelper;

namespace Collections.Web.Services;

public class DataExportService : IDataExportService
{
    private readonly IReadRepository<UserCollection> _collectionReadRepository;

    public DataExportService(IReadRepository<UserCollection> collectionReadRepository)
    {
        _collectionReadRepository = collectionReadRepository;
    }

    public async Task<MemoryStream> ExportCollectionToCsv(int collectionId)
    {
        var specification = new UserCollectionWithItemsByIdSpec(collectionId);
        var collection = await _collectionReadRepository.GetBySpecProjectedAsync<CollectionWithItemsViewModel>(specification);
        var output = new List<CollectionWithItemsViewModel>() { collection };
        using var stream = new MemoryStream();
        await using var streamWriter = new StreamWriter(stream);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.Context.RegisterClassMap<CollectionCsvMap>();
        foreach (var item in collection.Items)
        {
            foreach (var extraField in item.ExtraFields)
            {
                csvWriter.WriteRecord(collection);
                csvWriter.WriteRecord(item);
                csvWriter.WriteRecord(extraField);
                await csvWriter.NextRecordAsync();
            }
        }
        return stream;
    }
}