using FluentValidation;

namespace TrackFinance.Web.Endpoints.Expenses;

public class DeleteExpenseValidator : AbstractValidator<DeleteExpensesRequest>
{
  public DeleteExpenseValidator()
  {
    RuleFor(expense => expense.ExpenseId).GreaterThan(0);
  }
}
