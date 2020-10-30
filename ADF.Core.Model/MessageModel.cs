namespace ADF.Core.Model
{
    public class MessageModel<T>
    {
        public int Status { get; set; } = 200;
        public bool Success { get; set; } = false;
        public string Msg { get; set; } = "Server exception";
        public T Response { get; set; }

    }
}
