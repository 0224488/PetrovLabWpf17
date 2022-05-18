using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PetrovLabWpf17
{
	/// <summary>
	/// Interaction logic for ColorPicker.xaml
	/// </summary>
	public partial class ColorPicker : UserControl
	{
		static ColorPicker()
		{
			// Регистрация свойств зависимости
			ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
				new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
			RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker),
				new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
			GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),
				new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
			BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),
				 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

			ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
				typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
		}

		public ColorPicker()
		{
			InitializeComponent();
		}

		public static DependencyProperty ColorProperty;

		public static DependencyProperty RedProperty;
		public static DependencyProperty GreenProperty;
		public static DependencyProperty BlueProperty;

		public static readonly RoutedEvent ColorChangedEvent;

		#region properties
		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}
		public byte Red
		{
			get { return (byte)GetValue(RedProperty); }
			set { SetValue(RedProperty, value); }
		}
		public byte Green
		{
			get { return (byte)GetValue(GreenProperty); }
			set { SetValue(GreenProperty, value); }
		}
		public byte Blue
		{
			get { return (byte)GetValue(BlueProperty); }
			set { SetValue(BlueProperty, value); }
		}
		#endregion

		public event RoutedPropertyChangedEventHandler<Color> ColorChanged
		{
			add { AddHandler(ColorChangedEvent, value); }
			remove { RemoveHandler(ColorChangedEvent, value); }
		}

		private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if(sender is ColorPicker colorPicker)
			{
				Color color = colorPicker.Color;

				if(e.Property == RedProperty)
					color.R = (byte)e.NewValue;
				else if(e.Property == GreenProperty)
					color.G = (byte)e.NewValue;
				else if(e.Property == BlueProperty)
					color.B = (byte)e.NewValue;

				colorPicker.Color = color;
			}
		}

		private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if(sender is ColorPicker colorPicker)
			{
				Color newColor = (Color)e.NewValue;
				colorPicker.Red = newColor.R;
				colorPicker.Green = newColor.G;
				colorPicker.Blue = newColor.B;
			}
		}
	}
}
