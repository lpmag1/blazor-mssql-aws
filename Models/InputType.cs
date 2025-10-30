namespace Blazor.Models
{
  public class InputType
  {
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Input> Inputs { get; set; } = [];
    public List<InputTypeOption> InputTypeOptions { get; set; } = [];
  }
}