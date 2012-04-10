using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.UI;
using FubuValidation;
using JustWanna.Web.Actions.Profile;

namespace JustWanna.Web.Conventions
{
    public class JustWannaHtmlConventions : HtmlConventionRegistry
    {
        public JustWannaHtmlConventions()
        {
            ValidationAttributes();
        }
        // Declare policies for using validation attributes
        private void ValidationAttributes()
        {
            Editors.AddClassForAttribute<RequiredAttribute>("required");

            Labels.ModifyForAttribute<RequiredAttribute>(tag => tag.Add("span", span =>
            {
                span.Text("*");
                span.AddClass("req-indicator");
            }));
            UseLabelAndFieldLayout<BootstrapLayout>();
            Editors.ModifyForAttribute<MaximumStringLengthAttribute>((tag, att) =>
            {
                if (att.Length > -1)
                    tag.Attr("maxlength", att.Length);
            });
            Editors.ModifyForAttribute<GreaterOrEqualToZeroAttribute>(tag => tag.Attr("min", 0));
            Editors.ModifyForAttribute<GreaterThanZeroAttribute>(tag => tag.Attr("min", 1));
        }
    }
}