namespace EShop.Common.FluentBuilder
{
    public interface IBuilder<TEntity>

        where TEntity : class
    { 
        TEntity Build();
    }
}
