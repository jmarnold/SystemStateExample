using SystemStateExample.Domain;
using SystemStateExample.Infrastructure;
using FubuPersistence;
using StoryTeller;
using StoryTeller.Engine;
using StructureMap;

namespace SystemStateExample.StoryTeller.Fixtures.Data
{
    public class SystemStateFixture : Fixture
    {
        public SystemStateFixture()
        {
            Title = "The system state is";
        }

        private IEntityRepository _repository;
        private SmtpServerController _emails;

        public override void SetUp(ITestContext context)
        {
            _repository = Retrieve<IEntityRepository>();
            _emails = new SmtpServerController();

            Store(_emails);
        }

        public override void TearDown()
        {
            _emails.Shutdown();
        }
        
        [FormatAs("Start/Configure the SMTP Server")]
        public void StubEmailGateway()
        {
            var port = _emails.Start();
            Retrieve<IContainer>().Inject(new EmailSettings
                                          {
                                             Host = "localhost",
                                             Port = port
                                          });
        }

        public IGrammar TheSubscriptionPlans()
        {
            return CreateNewObject<SubscriptionPlan>(x =>
            {
                x.SetProperty(p => p.Name);
                x.Do = plan => _repository.Update(plan);
            }).AsTable("The Subscription Plans are").Before(() => _repository.DeleteAll<SubscriptionPlan>());
        }
    }
}