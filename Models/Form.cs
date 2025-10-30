namespace Blazor.Models
{
  public class Form
  {
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Input> Inputs { get; set; } = [];
  }
}