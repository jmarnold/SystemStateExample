using System.Collections.Generic;
using System.Linq;
using SystemStateExample.Account;
using SystemStateExample.Domain;
using SystemStateExample.StoryTeller.Fixtures.Data;
using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller;
using StoryTeller.Engine;

namespace SystemStateExample.StoryTeller.Fixtures.Register
{
    public class RegistrationFixture : ScreenFixture<CreateAccount>
    {
        public RegistrationFixture()
        {
            Title = "In the 'Registration' screen";

            EditableElementsForAllImmediateProperties();
        }

        protected override void beforeRunning()
        {
            Navigation.NavigateTo<RegistrationEndpoint>(x => x.get_register(null));
        }

        public IGrammar VerifySubscriptionPlans()
        {
            return VerifySetOf(() => plans())
                .Titled("Verify subscription plans")
                .MatchOn(x => x.Name);
        }

        private IEnumerable<SubscriptionPlan> plans()
        {
            return Driver.InputFor<CreateAccount>(x => x.Subscriptions)
                .FindElements(By.TagName("option"))
                .Select(x => new SubscriptionPlan {Name = x.Text})
                .ToList();
        }

        [FormatAs("Click the 'Create Account' button")]
        public void ClickTheSubmitButton()
        {
            Driver.FindElement(By.Id(RegistrationEndpoint.Submit)).Click();
        }

        [FormatAs("Verify that a confirmation email was received")]
        public bool VerifyEmail()
        {
            return Retrieve<SmtpServerController>().RecordedMessages().Any();
        }
    }
}