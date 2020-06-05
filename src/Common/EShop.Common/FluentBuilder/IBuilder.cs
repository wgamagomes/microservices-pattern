namespace EShop.Common.FluentBuilder
{
    public interface IBuilder<TEntity>

        where TEntity : class, new()
    { 
        TEntity Build();
    }
}
