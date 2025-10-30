namespace Blazor.Models
{
  public class Input
  {
    public int Id { get; set; }
    public required string Label { get; set; }
    public int InputTypeId { get; set; }
    public int FormId { get; set; }

    public InputType? InputType { get; set; }
    public Form? Form { get; set; }
  }
}