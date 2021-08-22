namespace Game.DTOs
{
    public class CustomActionResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
