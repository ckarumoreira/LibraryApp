using LibraryApp.Domain.Models;

namespace LibraryApp.Domain.Validations
{
    public class BorrowBookValidation : BookValidation, IValidator<Book>
    {
        public bool Validate(Book entity)
        {
            return ValidateAvailability(entity);
        }
    }
}