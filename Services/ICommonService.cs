namespace WeeClaims.Services {
  public interface ICommonService<T, TI> {
    public List<string> Errors { get; }
    Task<IEnumerable<T>> Get();
    Task<T> Add(TI customerInsertDto);
    bool Validate(TI dto);
  }
}
