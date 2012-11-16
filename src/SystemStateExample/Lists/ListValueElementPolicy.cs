using System;
using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuMVC.Core.UI.Elements;
using HtmlTags;

namespace SystemStateExample.Lists
{
    public class ListValueElementPolicy : ElementTagBuilder
    {
        public override bool Matches(ElementRequest subject)
        {
            return subject.Accessor.PropertyType.CanBeCastTo<IListValue>();
        }

        public override HtmlTag Build(ElementRequest request)
        {
            var accessorDef = request.ToAccessorDef();
            var literalList = accessorDef.Accessor.PropertyType.GetGenericArguments().Single();
            return BuildTag(request, literalList);
        }

        public static HtmlTag BuildTag(ElementRequest request, Type listType)
        {
            var list = request.Get<IServiceLocator>().GetInstance(listType) as IFieldList;
            return BuildTag(request, list);
        }

        public static HtmlTag BuildTag(ElementRequest request, IFieldList list)
        {
            var selectedValue = request.RawValue != null ? request.RawValue.ToString() : list.DefaultItem.ItemValue;

            return new SelectTag(tag =>
            {
                list.AllItems().Each(item => tag.Option(item.DisplayValue(), item.ItemValue));

                tag.SelectByValue(selectedValue);
            });
        }
    }
}