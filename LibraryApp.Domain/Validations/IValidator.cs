namespace LibraryApp.Domain.Validations
{
    public interface IValidator<TEntity>
    {
        bool Validate(TEntity entity);
    }
}