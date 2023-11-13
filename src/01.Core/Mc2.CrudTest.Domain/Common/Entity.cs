namespace Mc2.CrudTest.Domain.Common
{
    public class Entity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}