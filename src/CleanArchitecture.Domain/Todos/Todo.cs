using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Todos;

public class Todo : Entity
{
    public string Description { get; private set; } = string.Empty;
    public DateTime? DueDate { get; private set; }
    public int Priority { get; private set; }
    public bool IsCompleted { get; private set; } = false;

    private Todo(
        string description,
        DateTime? dueDate,
        int priority)
        : base(Guid.NewGuid())
    {
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }

    public static Todo Create(
        string description,
        DateTime? dueDate,
        int priority)
    {
        ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
        return new Todo(description, dueDate, priority);
    }

    public void Update(
        string description,
        DateTime dueDate,
        int priority,
        bool isCompleted)
    {
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = isCompleted;
    }
}