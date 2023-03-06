using System.Globalization;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;
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
        using var stream = new MemoryStream();
        await using var streamWriter = new StreamWriter(stream);
        await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
        csvWriter.Context.RegisterClassMap<CollectionCsvMap>();
        return await WriteCollectionToStream(collection, csvWriter, stream);
    }

    private static async Task<MemoryStream> WriteCollectionToStream(CollectionWithItemsViewModel collection, CsvWriter csvWriter,
        MemoryStream stream)
    {
        if (!collection.Items.Any())
        {
            csvWriter.WriteRecord(collection);
            return stream;
        }
        return await WriteItemsToStream(collection, csvWriter, stream);
    }

    private static async Task<MemoryStream> WriteItemsToStream(CollectionWithItemsViewModel collection, CsvWriter csvWriter,
        MemoryStream stream)
    {
        foreach (var item in collection.Items)
        {
            if (!item.ExtraFields.Any())
            {
                csvWriter.WriteRecord(collection);
                csvWriter.WriteRecord(item);
                await csvWriter.NextRecordAsync();
            }
            else
            {
                await WriteExtraFieldsToStream(collection, csvWriter, item);
            }
        }
        return stream;
    }

    private static async Task WriteExtraFieldsToStream(CollectionWithItemsViewModel collection, CsvWriter csvWriter,
        ItemViewModel item)
    {
        foreach (var extraField in item.ExtraFields)
        {
            csvWriter.WriteRecord(collection);
            csvWriter.WriteRecord(item);
            csvWriter.WriteRecord(extraField);
            await csvWriter.NextRecordAsync();
        }
    }
}