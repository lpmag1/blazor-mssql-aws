namespace Blazor.Models
{
  public class InputTypeOption
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int InputTypeId { get; set; }

    public InputType? InputType { get; set; }
  }
}