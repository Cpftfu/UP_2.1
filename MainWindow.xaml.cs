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

namespace UP_2._1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MagazineEntities context = new MagazineEntities();

		public MainWindow()
		{
			InitializeComponent();
			//ClientsDataGrid.ItemsSource = context.Clients.ToList();
		}

		//удаление(ого)
		private void forDelete_Click(object sender, RoutedEventArgs e)
		{
			//if(grid.SelectedItems != null)
			//{
			//	context.Clients.Remove(grid.SelectedItems as Clients);
			//
			//	context.SaveChanges();
			//	grid.ItemsSource = context.Clients.ToList();
			//}
		}

		//изменение(ого)
		private void forChange_Click(object sender, RoutedEventArgs e)
		{
			context.SaveChanges();
		}

		//добавление(ого)
		private void forAdd_Click(object sender, RoutedEventArgs e)
		{
			//Clients cl = new Clients();
			//cl.ClientName = forNew.Text;
			//
			//context.Clients.Add(cl);
			//
			//context.SaveChanges();
			//grid.ItemsSource = context.Clients.ToList();
		}

		private void firstGrid_Click(object sender, RoutedEventArgs e)
		{
			forGrid.Content = new FirstGrid();
		}

		private void secondGrid_Click(object sender, RoutedEventArgs e)
		{
			forGrid.Content = new SecondGrid();
		}

		private void thirdGrid_Click(object sender, RoutedEventArgs e)
		{
			forGrid.Content = new ThirdGrid();
		}
	}
}
