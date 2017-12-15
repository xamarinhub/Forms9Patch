﻿using System;
using Xamarin.Forms;

namespace Forms9Patch
{
    /// <summary>
    /// OBSOLETE: Use ButtonState
    /// </summary>
    [Obsolete("Use ButtonState")]
    public class ImageButtonState : ButtonState { }

    /// <summary>
    /// Describes the properties of a <see cref="StateButton"/> for a given state.
    /// </summary>
    [ContentProperty("HtmlText")]
    public class ButtonState : BindableObject, IButtonState
    {

        #region Obsolete Properties
        /// <summary>
        /// OBSOLETE: Use IconImageProperty
        /// </summary>
        [Obsolete("Use IconImageProperty")]
        public static BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(Forms9Patch.Image), typeof(ImageButtonState), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (bindable is ImageButtonState state && newValue is Image image)
                state.IconImage = image;
        });
        /// <summary>
        /// OBSOLETE: Use IconImage
        /// </summary>
        [Obsolete("Use IconImage")]
        public Image Image
        {
            get { return (Forms9Patch.Image)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// OBSOLETE: Use TextColorProperty
        /// </summary>
        [Obsolete("Use TextColorProperty")]
        public static readonly BindableProperty FontColorProperty = BindableProperty.Create("FontColor", typeof(Color), typeof(ImageButtonState), Color.Default, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (bindable is ImageButtonState state && newValue is Color color)
                state.TextColor = color;
        });
        /// <summary>
        /// OBSOLETE: Use TextColor
        /// </summary>
        [Obsolete("Use TextColor")]
        public Color FontColor
        {
            get { return (Color)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }
        }

        #endregion

        int _instances;

        #region IButtonState

        #region IconImage
        /// <summary>
        /// Backing store for the Image bindable property.
        /// </summary>
        public static BindableProperty IconImageProperty = BindableProperty.Create("IconImage", typeof(Image), typeof(ButtonState), null);
        /// <summary>
        /// Gets or sets the companion image.
        /// </summary>
        /// <value>The image.</value>
        public Image IconImage
        {
            get { return (Image)GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value); }
        }
        #endregion IconImage

        #region IconText
        /// <summary>
        /// Backing store for IconText property
        /// </summary>
        public static readonly BindableProperty IconTextProperty = BindableProperty.Create("IconText", typeof(string), typeof(ButtonState), null);
        /// <summary>
        /// Gets/Sets the IconText (Alternative to IconImage).
        /// </summary>
        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }
        #endregion IconText

        #region TrailingIcon
        internal bool TrailingIconSet;
        /// <summary>
        /// Backing store for the TrailiingImage property
        /// </summary>
        public static readonly BindableProperty TrailingIconProperty = BindableProperty.Create("TrailingIcon", typeof(bool), typeof(ButtonState), false,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).TrailingIconSet = true;
            })
        );
        /// <summary>
        /// Gets or sets if the IconImage / IconText will be before or after the button's text
        /// </summary>
        public bool TrailingIcon
        {
            get { return (bool)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }
        #endregion TrailingIcon

        #region TintIcon
        internal bool TintIconSet;
        /// <summary>
        /// Backing store for the TintIcon property
        /// </summary>
        public static readonly BindableProperty TintIconProperty = BindableProperty.Create("TintIcon", typeof(bool), typeof(ButtonState), true,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).TintIconSet = true;
            })
        );
        /// <summary>
        /// Gets or sets if the button's Icon will be tinted with the TextColor
        /// </summary>
        public bool TintIcon
        {
            get { return (bool)GetValue(TintIconProperty); }
            set { SetValue(TintIconProperty, value); }
        }
        #endregion TintIcon

        #region HasTightSpacing
        internal bool HasTightSpacingSet;
        /// <summary>
        /// The has tight spacing property.
        /// </summary>
        public static readonly BindableProperty HasTightSpacingProperty = BindableProperty.Create("HasTightSpacing", typeof(bool), typeof(ButtonState), default(bool),
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).HasTightSpacingSet = true;
            })
        );
        /// <summary>
        /// Gets or sets if the Icon/Image is close (TightSpacing) to text or at edge (not TightSpacing) of button.
        /// </summary>
        /// <value><c>true</c> if has tight spacing; otherwise, <c>false</c>.</value>
        public bool HasTightSpacing
        {
            get { return (bool)GetValue(HasTightSpacingProperty); }
            set { SetValue(HasTightSpacingProperty, value); }
        }
        #endregion HasTightSpacing

        #region Spacing
        internal bool SpacingSet;
        /// <summary>
        /// Backing store for the spacing property.
        /// </summary>
        public static readonly BindableProperty SpacingProperty = BindableProperty.Create("Spacing", typeof(double), typeof(ButtonState), -1.0,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).SpacingSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the spacing.
        /// </summary>
        /// <value>The spacing.</value>
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }
        #endregion Spacing

        #region Orientation
        internal bool OrientationSet;
        /// <summary>
        /// Backing store for the Button's orientation property.
        /// </summary>
        public static BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(StackOrientation), typeof(ButtonState), StackOrientation.Horizontal,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).OrientationSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the orientation of the iamge and label.
        /// </summary>
        /// <value>The image and label orientation.</value>
        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        #endregion

        #region ElementShape property
        internal bool ElementShapeSet;
        /// <summary>
        /// Backing store for the ElementShape property
        /// </summary>
        public static readonly BindableProperty ElementShapeProperty = BindableProperty.Create("ElementShape", typeof(ElementShape), typeof(ButtonState), default(ElementShape),
            propertyChanged: ((BindableObject bindable, object oldValue, object newValue) =>
            {
                ((IShape)bindable).ExtendedElementShape = ((ElementShape)newValue).ToExtendedElementShape();
                ((ButtonState)bindable).ElementShapeSet = true;
            })
            );
        /// <summary>
        /// controls the shape of a 
        /// </summary>
        public ElementShape ElementShape
        {
            get { return (ElementShape)GetValue(ElementShapeProperty); }
            set { SetValue(ElementShapeProperty, value); }
        }
        #endregion ElementShape property

        #region IBackground

        #region BackgroundImage
        /// <summary>
        /// Backing store for the BackgroundImage bindable property.
        /// </summary>
        public static BindableProperty BackgroundImageProperty = BindableProperty.Create("BackgroundImage", typeof(Image), typeof(ButtonState), null);
        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        public Image BackgroundImage
        {
            get { return (Image)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
        #endregion BackgroundImage

        #region IShape

        #region BackgroundColor
        internal bool BackgroundColorSet;
        /// <summary>
        /// Backing store for the BackgroundColor bindable property.
        /// </summary>
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("BackgroundColor", typeof(Color), typeof(ButtonState), (object)Color.Transparent,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).BackgroundColorSet = true;
            }
        );
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        #endregion BackgroundColor

        #region HasShadow
        internal bool HasShadowSet;
        /// <summary>
        /// Backing store for the HasShadow property
        /// </summary>
        public static readonly BindableProperty HasShadowProperty = BindableProperty.Create("HasShadow", typeof(bool), typeof(ButtonState), false,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).HasShadowSet = true;
            }
        );
        /// <summary>
        /// Gets and sets if the button casts a shadow
        /// </summary>
        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }
        #endregion HasShadow

        #region ShadowInverted
        internal bool ShadowInvertedSet;
        /// <summary>
        /// Backing store for the ShadowInverted bindable property.
        /// </summary>
        /// <remarks></remarks>
        public static readonly BindableProperty ShadowInvertedProperty = BindableProperty.Create("ShadowInverted", typeof(bool), typeof(ButtonState), false,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).ShadowInvertedSet = true;
            }
        );
        /// <summary>
        /// Gets or sets a flag indicating if the Frame's shadow is inverted. This is a bindable property.
        /// </summary>
        /// <value><c>true</c> if this instance's shadow is inverted; otherwise, <c>false</c>.</value>
        public bool ShadowInverted
        {
            get { return (bool)GetValue(ShadowInvertedProperty); }
            set { SetValue(ShadowInvertedProperty, value); }
        }
        #endregion

        #region OutlineColor
        internal bool OutlineColorSet;
        /// <summary>
        /// Backging store for the OutlineColor property
        /// </summary>
        public static readonly BindableProperty OutlineColorProperty = BindableProperty.Create("OutlineColor", typeof(Color), typeof(ButtonState), Color.Default,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).OutlineColorSet = true;
            }
        );
        /// <summary>
        /// Gets/sets the button's outline color
        /// </summary>
        public Color OutlineColor
        {
            get { return (Color)GetValue(OutlineColorProperty); }
            set { SetValue(OutlineColorProperty, value); }
        }
        #endregion

        #region OutlineRadius
        internal bool OutlineRadiusSet;
        /// <summary>
        /// Backing store for the OutlineRadius bindable property.
        /// </summary>
        public static readonly BindableProperty OutlineRadiusProperty = BindableProperty.Create("OutlineRadius", typeof(float), typeof(ButtonState), -1f,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).OutlineRadiusSet = true;
            }
        );
        /// <summary>
        /// Gets or sets the outline radius.
        /// </summary>
        /// <value>The outline radius.</value>
        public float OutlineRadius
        {
            get { return (float)GetValue(OutlineRadiusProperty); }
            set { SetValue(OutlineRadiusProperty, value); }
        }
        #endregion OutlineRadius

        #region OutlineWidth
        internal bool OutlineWidthSet;
        /// <summary>
        /// Backing store for the OutlineWidth bindable property.
        /// </summary>
        public static readonly BindableProperty OutlineWidthProperty = BindableProperty.Create("OutlineRadius", typeof(float), typeof(ButtonState), -1f,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).OutlineWidthSet = true;
            }
        );
        /// <summary>
        /// Gets or sets the width of the outline.
        /// </summary>
        /// <value>The width of the outline.</value>
        public float OutlineWidth
        {
            get { return (float)GetValue(OutlineWidthProperty); }
            set { SetValue(OutlineWidthProperty, value); }
        }
        #endregion OutlineWidth

        #region ExtendedElementShape property
        internal static readonly BindableProperty ExtendedElementShapeProperty = BindableProperty.Create("ExtendedElementShape", typeof(ExtendedElementShape), typeof(ButtonState), default(ExtendedElementShape));
        ExtendedElementShape IShape.ExtendedElementShape
        {
            get { return (ExtendedElementShape)GetValue(ExtendedElementShapeProperty); }
            set { SetValue(ExtendedElementShapeProperty, value); }
        }
        #endregion ExtendedElementShape property

        /*#region IgnoreShapePropertiesChanges
        /// <summary>
        /// Backging store for the IgnoreShapePropertiesChanges property
        /// </summary>
        public static BindableProperty IgnoreShapePropertiesChangesProperty = ShapeBase.IgnoreShapePropertiesChangesProperty;
        /// <summary>
        /// Prevent shape updates (to optimize performace)
        /// </summary>
        public bool IgnoreShapePropertiesChanges
        {
            get { return (bool)GetValue(ShapeBase.IgnoreShapePropertiesChangesProperty); }
            set { SetValue(ShapeBase.IgnoreShapePropertiesChangesProperty, value); }
        }
        #endregion IgnoreShapePropertyChanges*/

        #region IElement


        /// <summary>
        /// returns instance index (starts at 0)
        /// </summary>
        public int InstanceId { get; set; }

        #endregion IElement

        #endregion IShape

        #endregion IBackground

        #region ILabel

        #region Text
        /// <summary>
        /// Backing store for the Text bindable property.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(ButtonState), null);
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion Text

        #region HtmlText
        /// <summary>
        /// The formatted text property backing store.
        /// </summary>
        public static readonly BindableProperty HtmlTextProperty = BindableProperty.Create("HtmlText", typeof(string), typeof(ButtonState), null);
        /// <summary>
        /// Gets or sets the formatted text.
        /// </summary>
        /// <value>The formatted text.</value>
        public string HtmlText
        {
            get { return (string)GetValue(HtmlTextProperty); }
            set { SetValue(HtmlTextProperty, value); }
        }
        #endregion

        #region TextColor


        internal bool TextColorSet;
        /// <summary>
        /// Backing store for the FontColor bindable property.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(ButtonState), Color.Default,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).TextColorSet = (((Color)newValue) != Color.Default);
            })
        );
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        #endregion TextColor

        #region HorizontalTextAlignment
        internal bool HorizontalTextAlignmentSet;
        /// <summary>
        /// Backing store for the Button.Alignment bindable property
        /// </summary>
        public static BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create("HorizontalTextAlignment", typeof(TextAlignment), typeof(ButtonState), TextAlignment.Center,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).HorizontalTextAlignmentSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the alignment of the image and text.
        /// </summary>
        /// <value>The alignment (left, center, right).</value>
        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }
        #endregion HorizontalTextAlignment

        #region VerticalTextAlignment
        internal bool VerticalTextAlignmentSet;
        /// <summary>
        /// Backing store for the vertical alignment property.
        /// </summary>
        public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create("VerticalTextAlignment", typeof(TextAlignment), typeof(ButtonState), TextAlignment.Center,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).VerticalTextAlignmentSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the vertical alignment.
        /// </summary>
        /// <value>The vertical alignment.</value>
        public TextAlignment VerticalTextAlignment
        {
            get { return (TextAlignment)GetValue(VerticalTextAlignmentProperty); }
            set { SetValue(VerticalTextAlignmentProperty, value); }
        }
        #endregion VerticalTextAlignment

        #region LineBreakMode
        internal bool LineBreakModeSet;
        /// <summary>
        /// The line break mode property.
        /// </summary>
        public static readonly BindableProperty LineBreakModeProperty = BindableProperty.Create("LineBreakMode", typeof(LineBreakMode), typeof(ButtonState), LineBreakMode.TailTruncation,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).LineBreakModeSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the line break mode.
        /// </summary>
        /// <value>The line break mode.</value>
        public LineBreakMode LineBreakMode
        {
            get { return (LineBreakMode)GetValue(LineBreakModeProperty); }
            set { SetValue(LineBreakModeProperty, value); }
        }
        #endregion LineBreakMode

        #region AutoFit
        internal bool AutoFitSet;
        /// <summary>
        /// The fit property.
        /// </summary>
        public static readonly BindableProperty AutoFitProperty = BindableProperty.Create("AutoFit", typeof(AutoFit), typeof(ButtonState), AutoFit.Width,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).AutoFitSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the fit.
        /// </summary>
        /// <value>The fit.</value>
        public AutoFit AutoFit
        {
            get { return (AutoFit)GetValue(AutoFitProperty); }
            set { SetValue(AutoFitProperty, value); }
        }
        #endregion AutoFit

        #region Lines
        internal bool LinesSet;
        /// <summary>
        /// The lines property.
        /// </summary>
        public static readonly BindableProperty LinesProperty = BindableProperty.Create("Lines", typeof(int), typeof(ButtonState), 1,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).LinesSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>The lines.</value>
        public int Lines
        {
            get { return (int)GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }
        #endregion Lines

        #region MinFontSize
        internal bool MinFontSizeSet;
        /// <summary>
        /// The backing store for the minimum font size property.
        /// </summary>
        public static readonly BindableProperty MinFontSizeProperty = BindableProperty.Create("MinFontSize", typeof(double), typeof(ButtonState), -1.0,
            propertyChanged: ((bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).MinFontSizeSet = true;
            })
        );
        /// <summary>
        /// Gets or sets the minimum size of the font allowed during an autofit. 
        /// </summary>
        /// <value>The minimum size of the font.  Default=4</value>
        public double MinFontSize
        {
            get { return (double)GetValue(MinFontSizeProperty); }
            set { SetValue(MinFontSizeProperty, value); }
        }
        #endregion MinFontSize

        double ILabel.FittedFontSize { get; }

        double ILabel.SynchronizedFontSize { get; set; }

        #region IFontElement

        #region FontAttributes
        internal bool FontAttributesSet;
        /// <summary>
        /// Backing store for the FontAttributes bindable property.
        /// </summary>
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(ButtonState), Xamarin.Forms.FontAttributes.None,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).FontAttributesSet = true;
            }
        );//, BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate (ButtonState.FontAttributesPropertyChanged));
          /// <summary>
          /// Gets or sets the font attributes.
          /// </summary>
          /// <value>The font attributes.</value>
        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set
            {
                SetValue(FontAttributesProperty, value);
                //FontAttributesSet = true;
            }
        }
        #endregion FontAttributes

        #region FontSize
        internal bool FontSizeSet;
        /// <summary>
        /// Backing store for the FontSize bindable property.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(ButtonState), -1.0,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).FontSizeSet = ((double)newValue) >= 0;
            }
        );//, BindingMode.OneWay), null, new BindableProperty.BindingPropertyChangedDelegate (ButtonState.FontSizePropertyChanged));
          /// <summary>
          /// Gets or sets the size of the font.
          /// </summary>
          /// <value>The size of the font.</value>
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        #endregion FontSize

        #region FontFamily
        internal bool FontFamilySet;
        /// <summary>
        /// Backing store for the FontFamiily bindable property.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(ButtonState), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                ((ButtonState)bindable).FontFamilySet = newValue != null;
            }
        );//, BindingMode.OneWay), null, new BindableProperty.BindingPropertyChangedDelegate (ButtonState.FontFamilyPropertyChanged)); 
          /// <summary>
          /// Gets or sets the font family.
          /// </summary>
          /// <value>The font family.</value>
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set
            {
                SetValue(FontFamilyProperty, value);
                //FontFamilySet = true;
            }
        }
        #endregion FontFamily

        #endregion IFontElement

        #endregion ILabel

        #endregion IButtonState


        #region Construtors
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonState"/> class.
        /// </summary>
        public ButtonState()
        {
            InstanceId = _instances++;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonState"/> class to the same properties of Source instance.
        /// </summary>
        /// <param name="source">Source instance.</param>
        public ButtonState(ButtonState source)
        {
            #region IButtonState

            IconImage = source.IconImage;
            IconText = source.IconText;
            TrailingIcon = source.TrailingIcon;
            TrailingIconSet = source.TrailingIconSet;
            TintIcon = source.TintIcon;
            TintIconSet = source.TintIconSet;
            HasTightSpacing = source.HasTightSpacing;
            HasTightSpacingSet = source.HasTightSpacingSet;
            Spacing = source.Spacing;
            SpacingSet = source.SpacingSet;
            Orientation = source.Orientation;
            OrientationSet = source.OrientationSet;
            ElementShape = source.ElementShape;

            #region IBackground

            BackgroundImage = source.BackgroundImage;

            #region IShape
            BackgroundColor = source.BackgroundColor;
            BackgroundColorSet = source.BackgroundColorSet;
            HasShadow = source.HasShadow;
            HasShadowSet = source.HasShadowSet;
            ShadowInverted = source.ShadowInverted;
            ShadowInvertedSet = source.ShadowInvertedSet;
            OutlineColor = source.OutlineColor;
            OutlineColorSet = source.OutlineColorSet;
            OutlineRadius = source.OutlineRadius;
            OutlineRadiusSet = source.OutlineRadiusSet;
            OutlineWidth = source.OutlineWidth;
            OutlineWidthSet = source.OutlineWidthSet;
            //ExtendedElementShape is set by ElementShape setter.
            #endregion IShape

            #endregion IBackground

            #region ILabel
            Text = source.Text;
            HtmlText = source.HtmlText;
            TextColor = source.TextColor;
            TextColorSet = source.TextColorSet;
            HorizontalTextAlignment = source.HorizontalTextAlignment;
            HorizontalTextAlignmentSet = source.HorizontalTextAlignmentSet;
            VerticalTextAlignment = source.VerticalTextAlignment;
            VerticalTextAlignmentSet = source.VerticalTextAlignmentSet;
            LineBreakMode = source.LineBreakMode;
            LineBreakModeSet = source.LineBreakModeSet;
            AutoFit = source.AutoFit;
            AutoFitSet = source.AutoFitSet;
            Lines = source.Lines;
            LinesSet = source.LinesSet;
            MinFontSize = source.MinFontSize;
            MinFontSizeSet = source.MinFontSizeSet;

            #region IFontElement
            FontSize = source.FontSize;
            FontSizeSet = source.FontSizeSet;
            FontFamily = source.FontFamily;
            FontFamilySet = source.FontFamilySet;
            FontAttributes = source.FontAttributes;
            FontAttributesSet = source.FontAttributesSet;
            #endregion

            #endregion ILabel

            #endregion IButtonState
        }
        #endregion


        #region PropertyChange responders
        /// <param name="propertyName">The name of the property that changed.</param>
        /// <summary>
        /// Call this method from a child class to notify that a change happened on a property.
        /// </summary>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == HtmlTextProperty.PropertyName && HtmlText != null)
                Text = null;
            else if (propertyName == TextProperty.PropertyName && Text != null)
                HtmlText = null;
            else if (propertyName == IconImageProperty.PropertyName && IconImage != null)
                IconText = null;
            else if (propertyName == IconTextProperty.PropertyName && IconText != null)
                IconImage = null;
        }
        #endregion


        #region Operators

        /// <param name="state">State.</param>
        public static explicit operator string(ButtonState state)
        {
            return state.HtmlText ?? state.Text;
        }

        #endregion


        #region Layout (IShape.ShadowPadding)
        Thickness IShape.ShadowPadding() => ShapeBase.ShadowPadding(null, HasShadow);
        #endregion
    }
}

