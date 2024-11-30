namespace Museum.Data;

public interface IDataCommand<TParam, TResult>
{
    Task<TResult> ExecuteAsync(TParam param);
}