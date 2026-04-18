public interface ICommand<in T>
{
    public Task HAndleAsync( T context );
}

public interface IQuery<in T , R>
{
    public Task <R> HAndleAsync(T query);
}

public class QueryExample : IQuery<string, int>
{
    public Task<int> HAndleAsync(string query)
    {
        return Task.FromResult(query.Length);
    }
}