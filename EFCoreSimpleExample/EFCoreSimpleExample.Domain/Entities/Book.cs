using CSharpFunctionalExtensions;

namespace EFCoreSimpleExample.Domain.Entities;

public class Book : Entity
{
    public string Title { get; } = null!;
    public string Description { get; } = null!; 
    public string Author { get; } = null!;
    public DateTime CreatedDate { get; }
    public DateTime LastUpdatedDate { get; }

    public IEnumerable<Page> Pages { get; set; } = [];

    private Book() { }

    public Book(string title, string description, string author)
    {
        Title = title;
        Description = description;
        Author = author;

    }
}
