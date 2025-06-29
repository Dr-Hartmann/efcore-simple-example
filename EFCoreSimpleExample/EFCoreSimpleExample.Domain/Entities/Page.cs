using CSharpFunctionalExtensions;

namespace EFCoreSimpleExample.Domain.Entities;

public class Page : Entity
{
    public Book Book { get; } = null!;
    public string? Path { get; set; }

    private Page() { }

    public Page(Book book)
    {
        Book = book;
    }


    // Комментарии

    // содержание должно индексироваться и быть в вёрстке, для базы данных важно знать о...
}
