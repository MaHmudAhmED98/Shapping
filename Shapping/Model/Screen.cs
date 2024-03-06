namespace Shapping.Model
{
    public class Screen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public ICollection<ScreenPermission> ScreenPermission { get; set;}
    }
}
