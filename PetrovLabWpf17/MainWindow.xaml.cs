using System.Windows;
using System.Windows.Media;

namespace PetrovLabWpf17
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void colorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
		{
		}
	}
}
