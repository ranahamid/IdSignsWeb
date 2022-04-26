namespace Core.Entities
{
    /// <summary>
    /// This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    /// Using non-generic integer types for simplicity and to ease caching logic
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
    }
}
