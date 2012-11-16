using FubuCore;
using HtmlTags;

namespace SystemStateExample
{
    public class WelcomeEndpoint
    {
        public HtmlDocument get_welcome_Name(WelcomeMessage message)
        {
            var document = new HtmlDocument();
            document.Add(new HtmlTag("h1").Text("Hello, {0}".ToFormat(message.Name)));
            return document;
        }
    }
}