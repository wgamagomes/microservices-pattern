namespace EShop.Common.FluentBuilder
{
    public class Builder<TBuilder, TEntity> : IBuilder<TEntity>
        where TBuilder : IBuilder<TEntity>, new()
        where TEntity : class
    {
        protected  TEntity _entity;

        public TEntity Build()
        {
            return _entity;
        }

        public static TBuilder NewBuilder()
        {
            return new TBuilder();
        }
    }
}
