namespace FutureService.Domain.Models
{
    public class TodoItem
    {
        public TodoItem()
        {

        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public static TodoItem CreateTodoItem(string name, bool isComplete)
        {
            return new TodoItem
            {
                Name = name,
                IsComplete = isComplete
            };
        }

        public void SetStatus(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}
