using System.Collections.Generic;
using System.Linq;
using SystemStateExample.Domain;
using SystemStateExample.Lists;
using FubuPersistence;

namespace SystemStateExample.Account
{
    public class SubscriptionPlanList : IFieldList
    {
        private readonly IEntityRepository _repository;

        public SubscriptionPlanList(IEntityRepository repository)
        {
            _repository = repository;
        }

        public FieldListItem DefaultItem
        {
            get { return AllItems().First(); }
        }

        public IEnumerable<FieldListItem> AllItems()
        {
            return _repository.All<SubscriptionPlan>().Select(BuildListItem);
        }

        public FieldListItem BuildListItem(SubscriptionPlan plan)
        {
            return new FieldListItem(Name, plan.Name, plan.Id.ToString());
        }

        public string Name
        {
            get { return GetType().Name; }
        }
    }
}