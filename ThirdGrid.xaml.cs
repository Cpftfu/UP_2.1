using System;
using System.Collections.Generic;
using System.Globalization;
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
	/// Логика взаимодействия для ThirdGrid.xaml
	/// </summary>
	public partial class ThirdGrid : Page
	{
		private MagazineEntities context = new MagazineEntities();

		public ThirdGrid()
		{
			InitializeComponent();
			OrdersDataGrid.ItemsSource = context.Orders.ToList();
		}

		//добавление(ого)
		private void forAdd_Click(object sender, RoutedEventArgs e)
		{
			//Orders ord = new Orders();
			//
			//ord.OrderDate = forNew.Text;
			//ord.Client_ID = forNew.Text;
			//
			//context.Orders.Add(ord);
			//
			//context.SaveChanges();
			//OrdersDataGrid.ItemsSource = context.Orders.ToList();
			if (int.TryParse(forNew.Text, out int clientID) && DateTime.TryParseExact(forNew.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
			{
				Orders ord = new Orders();
				ord.OrderDate = orderDate; 
				ord.Client_ID = clientID;   

				context.Orders.Add(ord);
				context.SaveChanges();
				OrdersDataGrid.ItemsSource = context.Orders.ToList();
			}
			else
			{
				MessageBox.Show("Пожалуйста, введите корректный формат даты (дд.мм.гггг)");
			}
		}

		//изменение(ого) в кнопочке
		private void forChange_Click(object sender, RoutedEventArgs e)
		{
			if (OrdersDataGrid.SelectedItem != null)
			{
				var selected = OrdersDataGrid.SelectedItem as Orders;

				if (DateTime.TryParseExact(forNew.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
				{
					selected.OrderDate = orderDate; 
				}
				else
				{
					MessageBox.Show("Пожалуйста, введите корректный формат даты (дд.мм.гггг)");
					return;
				}

				if (int.TryParse(forNew.Text, out int clientID))
				{
					selected.Client_ID = clientID;
				}
				else
				{
					MessageBox.Show("Пожалуйста, введите корректное числовое значение для PriceProduct.");
					return;
				}

				context.SaveChanges();
				OrdersDataGrid.ItemsSource = context.Orders.ToList();
			}
		}

		private void forDelete_Click(object sender, RoutedEventArgs e)
		{
			Orders selectedOrders = OrdersDataGrid.SelectedItem as Orders;
			if (selectedOrders != null)
			{
				context.Orders.Remove(selectedOrders);
				context.SaveChanges();
				OrdersDataGrid.ItemsSource = context.Orders.ToList();
			}
		}
	}
}
