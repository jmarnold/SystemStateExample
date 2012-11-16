using FubuCore;
using FubuLocalization;

namespace SystemStateExample.Lists
{
    public class FieldListItem
    {
        private readonly string _listName;
        private readonly string _itemName;
        private readonly string _itemValue;

		public FieldListItem(string listName, string itemName)
			: this(listName, itemName, itemName)
		{
		}

    	public FieldListItem(string listName, string itemName, string itemValue)
        {
            _listName = listName;
            _itemName = itemName;
            _itemValue = itemValue;

            IsActive = true;
        }

        public string ItemValue
        {
            get { return _itemValue; }
        }

        public string ListName
        {
            get { return _listName; }
        }

        public string ItemName
        {
            get { return _itemName; }
        }

        public LocalString ToLocalString()
        {
            return new LocalString();
        }

        public StringToken ToStringToken()
        {
            var key = "List:{0}:{1}".ToFormat(_listName, _itemName);
            return StringToken.FromKeyString(key, _itemName);
        }

        public bool IsActive { get; set; }

        public string DisplayValue()
        {
            return ToStringToken().ToString();
        }
    }
}