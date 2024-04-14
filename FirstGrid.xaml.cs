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
	/// Логика взаимодействия для FirstGrid.xaml
	/// </summary>
	public partial class FirstGrid : Page
	{
		private MagazineEntities context = new MagazineEntities();

		public FirstGrid()
		{
			InitializeComponent();
			ClientsDataGrid.ItemsSource = context.Clients.ToList();
		}

		//добавление(ого)
		private void forAdd_Click(object sender, RoutedEventArgs e)
		{
			Clients cl = new Clients();

			cl.ClientName = forNew.Text;
			cl.ClientSurname = forNew.Text;
			cl.ClientMiddlename = forNew.Text;
			cl.PhoneNumber = forNew.Text;
			
			context.Clients.Add(cl);
			
			context.SaveChanges();
			ClientsDataGrid.ItemsSource = context.Clients.ToList();
		}

		//изменение(ого) в кнопочке
		private void forChange_Click(object sender, RoutedEventArgs e)
		{
			//context.SaveChanges();
			if(ClientsDataGrid.SelectedItem != null)
			{
				var selected = ClientsDataGrid.SelectedItem as Clients;

				selected.ClientName = forNew.Text;
				selected.ClientSurname = forNew.Text;
				selected.ClientMiddlename = forNew.Text;
				selected.PhoneNumber = forNew.Text;

				context.SaveChanges();
				ClientsDataGrid.ItemsSource = context.Clients.ToList();
			}
		}

		//удаление(ого)
		private void forDelete_Click(object sender, RoutedEventArgs e)
		{
			Clients selectedClient = ClientsDataGrid.SelectedItem as Clients;
			if (selectedClient != null)
			{
				context.Clients.Remove(selectedClient);
				context.SaveChanges();
				ClientsDataGrid.ItemsSource = context.Clients.ToList();
			}
		}

		//изменение в гриде
		private void ClientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = ClientsDataGrid.SelectedItem as Clients;

			forNew.Text = selected.ClientName;
			forNew.Text = selected.ClientSurname;
			forNew.Text = selected.ClientMiddlename;
			forNew.Text = selected.PhoneNumber;

			context.SaveChanges();
			ClientsDataGrid.ItemsSource = context.Clients.ToList();
		}
	}
}
