namespace WeeClaims.Repository {
  public interface IRepository<TEntity> {
    Task<IEnumerable<TEntity>> Get();
    Task Add(TEntity entity);
    Task Save();
    IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
  }
}
