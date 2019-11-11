namespace Common.Core.Core
{
    public class DataPagging : IDataPagging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public IResult Result { get; set; }
        public DataPagging(int pageNumber, int pageSize, int totalPage, IResult result)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPage = totalPage;
            Result = result;
        }
    }
}
