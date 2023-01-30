using Module5HW1.Helpers;
using Module5HW1.Models;

namespace Module5HW1.Services
{
    public abstract class BaseService
    {
        protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
            where TResult : Status, new()
        {
            try
            {
                return await action();
            }
            catch (BusinessException e)
            {
                return new TResult { StatusCode = e.StatusCode, Message = e.Message };
            }
        }
    }
}
