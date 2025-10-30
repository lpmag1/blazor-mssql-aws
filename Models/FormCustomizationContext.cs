using Microsoft.EntityFrameworkCore;

namespace Blazor.Models
{
  public class FormCustomizationContext : DbContext
  {
    public DbSet<Form> Forms { get; set; }
    public DbSet<Input> Inputs { get; set; }
    public DbSet<InputType> InputTypes { get; set; }
    public DbSet<InputTypeOption> InputTypeOptions { get; set; }
    public string DbPath { get; }

    public FormCustomizationContext()
    {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      DbPath = Path.Join(path, "app.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
  }
}