namespace EShop.Framework.FluentBuilder
{
    public interface IBuilder<TEntity>

        where TEntity : class, new()
    { 
        TEntity Build();
    }
}
