using LibraryApp.Domain.Models;

namespace LibraryApp.Domain.Validations
{
    public abstract class BookValidation
    {
        protected bool ValidateAuthor(Book entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Author))
            {
                return false;
            }

            return true;
        }

        protected bool ValidateAvailability(Book entity)
        {
            return entity.IsAvailable;
        }

        protected bool ValidateTitle(Book entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                return false;
            }

            return true;
        }
    }
}