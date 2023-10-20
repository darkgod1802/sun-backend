using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrackFinance.Core.TransactionAgregate;
using TrackFinance.SharedKernel.Interfaces;

namespace TrackFinance.Web.Endpoints.Expenses;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteExpensesRequest>
    .WithoutResult
{
  private readonly IRepository<Transaction> _repository;

  public Delete(IRepository<Transaction> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteExpensesRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Expenses",
      Description = "Delete a Expense Saved",
      OperationId = "Expenses.Delete",
      Tags = new[] { "ExpensesEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteExpensesRequest request, CancellationToken cancellationToken = default)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.ExpenseId);
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();
  }
}
