using System.Reflection;
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
      var path = Assembly.GetExecutingAssembly().Location;
      var folder = Path.GetDirectoryName(path);
      DbPath = Path.Join(folder, "app.db");
      Console.WriteLine($"Database path: {DbPath}");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlite($"Data Source={DbPath}")
        .UseSeeding((context, _) =>
        {
          var testInputType = context.Set<InputType>().FirstOrDefault();
          if (testInputType == null)
          {
            var testInputTypes = new List<InputType>
            {
              new() {
                Name = "Text",
              },
              new() {
                Name = "Number",
              },
              new() {
                Name = "Date",
              },
              new() {
                Name = "Dropdown",
              }
            };
            context.Set<InputType>().AddRange(testInputTypes);
          }
          context.SaveChanges();

          var testForm = context.Set<Form>().FirstOrDefault();
          if (testForm == null)
          {
            var form = new Form
            {
              Name = "Test Form",
              Inputs =
              [
                new Input
                  {
                    Label = "First Name",
                    InputTypeId = 1, // Text
                  },
                  new Input
                  {
                    Label = "Age",
                    InputTypeId = 2, // Number
                  },
                  new Input
                  {
                    Label = "Birth Date",
                    InputTypeId = 3, // Date
                  },
                  new Input
                  {
                    Label = "Favorite Color",
                    InputTypeId = 4, // Dropdown
                  }
              ]
            };
            context.Set<Form>().Add(form);
          }

          var testInputTypeOptions = context.Set<InputTypeOption>().FirstOrDefault();
          if (testInputTypeOptions == null)
          {
            var inputTypeOptions = new List<InputTypeOption>
            {
              new() {
                InputTypeId = 4, // Dropdown
                Name = "Red",
              },
              new() {
                InputTypeId = 4, // Dropdown
                Name = "Green",
              },
              new() {
                InputTypeId = 4, // Dropdown
                Name = "Blue",
              }
            };
            context.Set<InputTypeOption>().AddRange(inputTypeOptions);
          }

          context.SaveChanges();
        });
    }
  }
}