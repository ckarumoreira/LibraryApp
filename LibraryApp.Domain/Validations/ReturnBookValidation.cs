using LibraryApp.Domain.Models;

namespace LibraryApp.Domain.Validations
{
    public class ReturnBookValidation : BookValidation, IValidator<Book>
    {
        public bool Validate(Book entity)
        {
            return !ValidateAvailability(entity);
        }
    }
}