namespace EShop.Common.FluentBuilder.Interfaces
{
    public interface IBuilder<TEntity>

        where TEntity : class, new()
    { 
        TEntity Build();
    }
}
