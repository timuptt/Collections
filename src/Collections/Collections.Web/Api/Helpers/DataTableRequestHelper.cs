namespace Collections.Web.Api.Helpers;

public class DataTableRequestHelper
{
    public string? Draw { get; }
    
    public string? Start { get; }
    
    public string? Length { get; }
    
    public string? SortColumn { get; }
    
    public string? SortColumnDirection { get; }

    public string? SearchValue { get; }

    public int PageSize => Length != null ? Convert.ToInt32(Length) : 0;
    
    public int Skip => Start != null ? Convert.ToInt32(Start) : 0;

    public DataTableRequestHelper(HttpRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        Draw = request.Form["draw"].FirstOrDefault();
        Start = request.Form["start"].FirstOrDefault();
        Length = request.Form["length"].FirstOrDefault();
        SortColumn = request.Form["columns[" + request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        SortColumnDirection = request.Form["order[0][dir]"].FirstOrDefault();
        SearchValue = request.Form["search[value]"].FirstOrDefault();
    }
}