namespace MVCAssign1.ViewModel
{
    public class EmailViewModel
    {

        public string FromEmail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Country { get; set; }
    }
}
