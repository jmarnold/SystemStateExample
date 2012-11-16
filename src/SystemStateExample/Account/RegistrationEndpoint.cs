using FubuCore;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI;
using HtmlTags;

namespace SystemStateExample.Account
{
    public class RegistrationEndpoint
    {
        public static readonly string Submit = "Submit";

        private readonly IServiceLocator _services;
        private readonly IFubuRequest _request;

        public RegistrationEndpoint(IServiceLocator services, IFubuRequest request)
        {
            _services = services;
            _request = request;
        }

        public HtmlDocument get_register(CreateAccount account)
        {
            var document = new FubuHtmlDocument<CreateAccount>(_services, _request);

            var form = document.FormFor<CreateAccount>()
                .Append(document.Edit(x => x.Name))
                .Append(document.Edit(x => x.EmailAddress))
                .Append(document.Edit(x => x.Password))
                .Append(document.Edit(x => x.Subscriptions))
                .Append(new HtmlTag("input").Attr("type", "submit").Attr("value", "Create Account").Id(Submit));

            document.Add("h1").Text("Create New Account");
            document.Add(form);

            return document;
        }
    }
}