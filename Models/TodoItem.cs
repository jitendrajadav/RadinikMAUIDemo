namespace RadinikMAUIDemo.Models
{
    public class TodoItem : BaseEntity
    {
        public string Name { get; set; }
        public bool Done { get; internal set; }
    }
}