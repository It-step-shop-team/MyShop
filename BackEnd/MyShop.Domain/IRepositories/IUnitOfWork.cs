namespace MyShop.Domain.IRepositories
{
    /// <summary>
    /// Represents a unit of work that groups one or more repository operations into a single transactional scope.
    /// Provides a method to commit changes to the database.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes made in the current unit of work to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
