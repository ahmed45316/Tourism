namespace Common.Core.Extensions
{
    public class SortModel
    {
        public string ColId { get; set; } = "id";
        public string Sort { get; set; } = "asc";
        public string PairAsSqlExpression => $"{ColId} {Sort}";
    }
}
