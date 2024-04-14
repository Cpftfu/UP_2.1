using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
	/// Логика взаимодействия для SecondGrid.xaml
	/// </summary>
	public partial class SecondGrid : Page
	{
		private MagazineEntities context = new MagazineEntities();

		public SecondGrid()
		{
			InitializeComponent();
			ProductsDataGrid.ItemsSource = context.Products.ToList();
		}

		//добавление(ого)
		private void forAdd_Click(object sender, RoutedEventArgs e)
		{
			Products pr = new Products();

			pr.ProductName = forNew.Text;
			//pr.PriceProduct = forNew.Text;

			context.Products.Add(pr);

			context.SaveChanges();
			ProductsDataGrid.ItemsSource = context.Products.ToList();
		}

		//изменение(ого) в кнопочке
		private void forChange_Click(object sender, RoutedEventArgs e)
		{
			if (ProductsDataGrid.SelectedItem != null)
			{
				var selected = ProductsDataGrid.SelectedItem as Products;

				selected.ProductName = forNew.Text;
				//selected.PriceProduct = forNew.Text;

				context.SaveChanges();
				ProductsDataGrid.ItemsSource = context.Products.ToList();
			}
		}

		//удаление(ого)
		private void forDelete_Click(object sender, RoutedEventArgs e)
		{
			Products selectedProducts = ProductsDataGrid.SelectedItem as Products;
			if (selectedProducts != null)
			{
				context.Products.Remove(selectedProducts);
				context.SaveChanges();
				ProductsDataGrid.ItemsSource = context.Products.ToList();
			}
		}

		//изменение в гриде
		private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = ProductsDataGrid.SelectedItem as Products;

			forNew.Text = selected.ProductName;
			//forNew.Text = selected.PriceProduct;

			context.SaveChanges();
			ProductsDataGrid.ItemsSource = context.Products.ToList();
		}
	}
}
