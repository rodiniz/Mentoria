using FluentValidation.Results;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors){


    public ValidationFailed(ValidationFailure error):this(new []{ error })
    {       
    }
}