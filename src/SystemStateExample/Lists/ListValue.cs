using System;

namespace SystemStateExample.Lists
{
    public interface IListValue
    {
        string Label { get; }
        string Value { get; }
    }

    public class ListValue<T> : IListValue
        where T : IFieldList
    {
        public ListValue()
        {
        }

        public ListValue(string value)
        {
        	Label = value;
            Value = value;
        }

        public string Label { get; set; }
        public string Value { get; set; }

        public Guid EntityIdentifier()
        {
            Guid id = Guid.Empty;
            ForValue<Guid>(value => id = value);

            return id;
        }

        public void ForValue<TValue>(Action<TValue> action)
        {
            try
            {
                var value = (TValue)Convert.ChangeType(Value, typeof(TValue));
                action(value);
            }
            catch (Exception)
            {
                // that's right, we're swallowing it. We'll make it smarter later
            }
            
        }

        public override string ToString()
        {
            return new FieldListItem(typeof (T).Name, Label, Value).ToStringToken().ToString();
        }

        //public static ListValue<T> Default()
        //{
        //    var listItem = new T().DefaultItem;
        //    return new ListValue<T>(listItem.ItemName);
        //}

        public bool Equals(ListValue<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Value, Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ListValue<T>)) return false;
            return Equals((ListValue<T>) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}