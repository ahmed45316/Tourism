namespace Common.Core.Core
{
    public interface IDataPagging
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalPage { get; set; }
        IResult Result { get; set; }
    }
}
