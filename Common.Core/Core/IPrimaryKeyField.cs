namespace Common.Core.Core
{
   public interface IPrimaryKeyField<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}