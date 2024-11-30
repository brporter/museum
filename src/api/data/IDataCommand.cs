namespace Museum.Data;

public interface IDataCommand<TParam>
{
    Task ExecuteAsync(TParam param);
}

public interface IDataCommand<TParam, TResult>
{
    Task<TResult> ExecuteAsync(TParam param);
}