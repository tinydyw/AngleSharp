﻿namespace AngleSharp.DOM.Html
{
    using System;

    /// <summary>
    /// Represents the HTML option element.
    /// </summary>
    sealed class HTMLOptionElement : HTMLElement, ISelectScopeElement, IImpliedEnd, IHtmlOptionElement
    {
        #region Fields

        Boolean? _selected;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new HTML option element.
        /// </summary>
        internal HTMLOptionElement()
        {
            _name = Tags.Option;
        }

        #endregion           
        
        #region Properties

        /// <summary>
        /// Gets or sets if the option is enabled or disabled.
        /// </summary>
        public Boolean Disabled
        {
            get { return GetAttribute(AttributeNames.Disabled) != null; }
            set { SetAttribute(AttributeNames.Disabled, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets the associated HTML form element.
        /// </summary>
        public IHtmlFormElement Form
        {
            get { return GetAssignedForm(); }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public String Label
        {
            get { return GetAttribute(AttributeNames.Label); }
            set { SetAttribute(AttributeNames.Label, value); }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public String Value
        {
            get { return GetAttribute(AttributeNames.Value) ?? String.Empty; }
            set { SetAttribute(AttributeNames.Value, value); }
        }

        /// <summary>
        /// Gets the index of the option element.
        /// </summary>
        public Int32 Index
        {
            get
            {
                var group = _parent as HTMLOptGroupElement;

                if(group != null)
                {
                    int i = 0;

                    foreach (var child in group.Children)
                    {
                        if (child == this)
                            return i;
                        else
                            i++;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the text of the option.
        /// </summary>
        public String Text
        {
            get { return TextContent.CollapseAndStrip(); }
            set { TextContent = value; }
        }

        /// <summary>
        /// Gets or sets if the option is selected by default.
        /// </summary>
        public Boolean DefaultSelected
        {
            get { return GetAttribute(AttributeNames.Selected) != null; }
            set { SetAttribute(AttributeNames.Selected, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets or sets if the option is currently selected.
        /// </summary>
        public Boolean Selected
        {
            get { return _selected.HasValue ? _selected.Value : DefaultSelected; }
            set { _selected = value; }
        }

        #endregion

        #region Internal properties

        /// <summary>
        /// Gets if the node is in the special category.
        /// </summary>
        protected internal override Boolean IsSpecial
        {
            get { return false; }
        }

        #endregion
    }
}
