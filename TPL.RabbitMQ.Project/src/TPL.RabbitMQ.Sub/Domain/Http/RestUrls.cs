namespace TPL.RabbitMQ.Sub.Domain.Http
{
    public class RestUrls
    {
        public string UrlBase { get; set; }
        public OtherApi OtherApi { get; set; }
    }

    public class OtherApi
    {
        public string UrlService { get; set; }
    }
}
