using System.Collections.Generic;
using FubuMVC.Core.UI.Forms;
using HtmlTags;

namespace JustWanna.Web.Actions.Profile
{
    public class BootstrapLayout : ILabelAndFieldLayout
    {
        private HtmlTag _containingDiv;
        private HtmlTag _labelPlaceholder;
        private HtmlTag _inputContainer;

        public BootstrapLayout()
        {
            _containingDiv = new HtmlTag("div").AddClass("control-group");
            _labelPlaceholder = new HtmlTag("div");
            _inputContainer = new HtmlTag("div").AddClass("controls");
            _containingDiv.Append(_labelPlaceholder);
            _containingDiv.Append(_inputContainer);
        }

        public IEnumerable<HtmlTag> AllTags()
        {
            yield return _containingDiv;
        }

        public HtmlTag LabelTag
        {
            get { return _containingDiv.FirstChild(); }
            set { _containingDiv.ReplaceChildren(value, _inputContainer); }
        }

        public HtmlTag BodyTag
        {
            get { return _inputContainer.FirstChild() ?? _inputContainer; }
            set { _inputContainer.ReplaceChildren(value); }
        }

        public override string ToString()
        {
            return _containingDiv.ToString();
        }

    }
}