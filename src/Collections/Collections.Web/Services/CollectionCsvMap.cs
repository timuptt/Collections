using System.Globalization;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.Collection;
using CsvHelper.Configuration;

namespace Collections.Web.Services;

public class CollectionCsvMap : ClassMap<CollectionWithItemsViewModel>
{
    public CollectionCsvMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(c => c.ProfileFullName).Name("Author");
    }
}