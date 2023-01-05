namespace ChatApp.Models
{
    public class Message
    {
        public Message()
        {
        }

        public Message(string _username, string _userColor, string _message, string _group)
        {
            username = _username;
            userColor = _userColor;
            message = _message;
            group = _group;
        }

        public int Id { get; set; }

        public string username { get; set; }

        public string userColor { get; set; }

        public string message { get; set; }

        public string group { get; set; }
    }
}
