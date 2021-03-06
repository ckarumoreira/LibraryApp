﻿using LibraryApp.Domain.Models;

namespace LibraryApp.Domain.Validations
{
    public class CreateBookValidation : BookValidation, IValidator<Book>
    {
        public bool Validate(Book entity)
        {
            return ValidateAuthor(entity) && ValidateTitle(entity);
        }
    }
}