﻿namespace CqrsExperiments.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IReadOnlyCollection<ValidationError> errors) : base ("Validation failed")
        {
            Errors = errors;
        }

        public IReadOnlyCollection<ValidationError> Errors { get; }
    }
}
