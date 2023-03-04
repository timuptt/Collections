using System.Net;
using Collections.ApplicationCore.Models;

namespace Collections.Shared.Interfaces;

public interface IDataExportService<T> where T : class 
{
    public Task<MemoryStream> ExportToCsw(T dataObject);
}