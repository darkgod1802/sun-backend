using FluentValidation;
using TrackFinance.Web.Endpoints.Expenses;

namespace TrackFinance.Web.Endpoints.Expenses;

public class GetExpensesByIdValidator : AbstractValidator<GetExpenseByIdRequest>
{
  public GetExpensesByIdValidator()
  {
    RuleFor(expense => expense.expenseId).GreaterThan(0);
  }
}
