using System.Collections.Generic;

namespace SystemStateExample.Lists
{
    public interface IFieldList
    {
        FieldListItem DefaultItem { get; }
        IEnumerable<FieldListItem> AllItems();
        string Name { get; }
    }
}