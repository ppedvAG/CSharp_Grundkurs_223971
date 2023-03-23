using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M015
{
	public partial class MainWindow : Window
	{
		public int Zaehler = 0;

		public MainWindow()
		{
			InitializeComponent();
			CB.ItemsSource = new List<string>() { "E1", "E2", "E3" }; //ComboBox mit Elementen befüllen
			LB.ItemsSource = new List<string>() { "E1", "E2", "E3" }; //ListBox mit Elementen befüllen
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//TB.Text = "" + ++Zaehler;
			TB.Text = LB.SelectedItems.OfType<string>().Aggregate("", (agg, str) => agg += str + ", ").Trim(',', ' ');


			W2 w = new W2();
			//w.Show(); //freies normalen Fenster, blockiert nicht den Hintergrund
			bool? b = w.ShowDialog();
			if (b == true)
			{
				TB.Text = "Button gedrückt";
			}
			else
			{
				TB.Text = "Button nicht gedrückt";
			}
		}

		private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TB.Text = e.AddedItems[0].ToString();
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			CheckBox check = sender as CheckBox;
			TB.Text = check.Content.ToString() + " checked";
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckBox check = sender as CheckBox;
			TB.Text = check.Content.ToString() + " unchecked";
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Willst du wirklich beenden?", "Beenden?", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
				Environment.Exit(0);
		}
	}
}
