namespace EShop.Common.FluentBuilder
{
    public abstract class Builder<TBuilder, TEntity> : IBuilder<TEntity>
        where TBuilder : IBuilder<TEntity>, new()
        where TEntity : class, new()
    {
        protected  TEntity _entity;

        public Builder()
        {
            _entity = new TEntity();
        }

        public TEntity Build()
        {
            return _entity;
        }
    }
}
