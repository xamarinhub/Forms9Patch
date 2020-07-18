﻿using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using P42.Utils;
using System;

namespace Forms9Patch
{
    /// <summary>
    /// Multi picker.
    /// </summary>
    [DesignTimeVisible(true)]
    public class MultiPicker : SinglePicker
    {
        #region Properties

        /// <summary>
        /// The indexes currently selected
        /// </summary>
        public List<int> SelectedIndexes
        {
            get
            {
                var result = new List<int>();
                var itemsSource = ItemsSource.Cast<object>().ToArray();
                for (int i = 0; i < itemsSource.Length; i++)
                {
                    if (SelectedItems.Contains(itemsSource[i]))
                        result.Add(i);
                }
                return result;
            }
        }

        #endregion


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Forms9Patch.MultiPicker"/> class.
        /// </summary>
        public MultiPicker()
        {
            PlainTextCellType = typeof(MultiPickerCellContentView);
            HtmlTextCellType = typeof(MultiPickerHtmlCellContentView);
            SelectionMode = SelectionMode.Multiple;

            ItemTemplates.Clear();
            ItemTemplates.Add(typeof(string), PlainTextCellType);
        }
        #endregion


        #region Cell Template
        [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
        protected class MultiPickerHtmlCellContentView : MultiPickerCellContentView
        {
            public MultiPickerHtmlCellContentView()
            {
                itemLabel.TextType = TextType.Html;
            }

            protected override void OnBindingContextChanged()
            {
                if (!P42.Utils.Environment.IsOnMainThread)
                {
                    Device.BeginInvokeOnMainThread(OnBindingContextChanged);
                    return;
                }

                base.OnBindingContextChanged();

                if (BindingContext is IHtmlString htmlObject)
                    itemLabel.Text = htmlObject.ToHtml();
                else if (BindingContext != null)
                    itemLabel.Text = BindingContext?.ToString();
                else
                    itemLabel.Text = itemLabel.Text = null;
            }
        }

        [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
        protected class MultiPickerCellContentView : SinglePickerCellContentView
        {
            #region Fields
            protected readonly Label checkLabel = new Label
            {
                Text = "✓",
                TextColor = Color.Blue,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };
            #endregion


            #region Constructors
            public MultiPickerCellContentView()
            {
                ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(30,GridUnitType.Absolute)},
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
            };
                Children.Add(checkLabel, 0, 0);
            }
            #endregion


            #region Change management
            protected override void OnPropertyChanged(string propertyName = null)
            {
                if (!P42.Utils.Environment.IsOnMainThread)
                {
                    Device.BeginInvokeOnMainThread(() => OnPropertyChanged(propertyName));
                    return;
                }

                base.OnPropertyChanged(propertyName);

                if (propertyName == IsSelectedProperty.PropertyName)
                    checkLabel.IsVisible = IsSelected;
            }

            #endregion

        }
        #endregion
    }
}

