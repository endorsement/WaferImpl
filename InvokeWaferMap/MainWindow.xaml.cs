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

namespace InvokeWaferMap
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		private void gen()
		{
			var lst = new List<int>();
			for (int y = 0; y < 45; y++)
			{
				lst.Add(80);
			}
			WaferMapImpl.MakeWafer(lst);
		}

		private void New_Click(object sender, RoutedEventArgs e)
		{
			gen();
		}
		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var s = new Setting();
			s.ShowDialog();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Remove_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
