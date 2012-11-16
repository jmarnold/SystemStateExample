using SystemStateExample.Lists;

namespace SystemStateExample.Account
{
    public class CreateAccount
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public ListValue<SubscriptionPlanList> Subscriptions { get; set; }
    }
}