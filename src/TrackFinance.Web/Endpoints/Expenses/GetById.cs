using System.Net.Mime;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TrackFinance.Core.TransactionAgregate;
using TrackFinance.Core.TransactionAgregate.Enum;
using TrackFinance.Core.TransactionAgregate.Specifications;
using TrackFinance.SharedKernel.Interfaces;
using TrackFinance.Web.Endpoints.Expenses;

namespace TrackFinance.Web.Endpoints.Expenses;

public class GetById : EndpointBaseAsync
    .WithRequest<GetExpenseByIdRequest>
    .WithActionResult<GetExpensesByIdResponse>
{
  private readonly IRepository<Transaction> _repository;

  public GetById(IRepository<Transaction> repository)
  {
    _repository = repository;
  }

  [Produces(MediaTypeNames.Application.Json)]
  [HttpGet(GetExpenseByIdRequest.Route)]
  [SwaggerOperation(
      Summary = "Gets a single Expense",
      Description = "Gets a single Expens by Id",
      OperationId = "Expense.GetById",
      Tags = new[] { "ExpensesEndpoints" })
  ]
  public override async Task<ActionResult<GetExpensesByIdResponse>> HandleAsync([FromRoute] GetExpenseByIdRequest request,
      CancellationToken cancellationToken)
  {
    var transaction = new TransactionById(request.expenseId, TransactionType.Expense);
    var entity = await _repository.GetBySpecAsync(transaction, cancellationToken);
    if (entity == null) return NotFound();

    var response = new GetExpensesByIdResponse
    (
        description: entity.Description,
        amount: entity.Amount,
        transactionDescriptionType: entity.TransactionDescriptionType,
        expenseDate: entity.ExpenseDate
    );
    return Ok(response);
  }
}
