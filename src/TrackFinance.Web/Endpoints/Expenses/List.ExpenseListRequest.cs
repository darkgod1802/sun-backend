namespace TrackFinance.Web.Endpoints.Expenses;

public class ExpenseListRequest
{
  public const string Route = "/Expanses/{UserId:int}/user";
  public static string BuildRoute(int userId) => Route.Replace("{UserId:int}", userId.ToString());
  public int UserId { get; set; }
}
