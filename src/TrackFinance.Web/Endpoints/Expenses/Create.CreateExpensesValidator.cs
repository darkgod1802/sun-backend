using FluentValidation;
using TrackFinance.Web.Endpoints.Expenses;

namespace TrackFinance.Web.Endpoints.Expenses;

public class CreateExpensesValidator : AbstractValidator<CreateExpensesRequest>
{
  public CreateExpensesValidator() 
  { 
    RuleFor(expense => expense.Description).NotEmpty().NotNull();
    RuleFor(expense => expense.Amount).GreaterThan(0);
  }
}
