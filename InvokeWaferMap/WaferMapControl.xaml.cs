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
	/// WaferMapControl.xaml の相互作用ロジック
	/// </summary>
	public partial class WaferMapControl : UserControl
	{

		/// <summary>
		/// 管理用のリスト
		/// </summary>
		private List<List<Border>> WaferBorder = new List<List<Border>>();

		public WaferMapControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// WaferMapを生成…
		/// </summary>
		/// <param name="xy"></param>
		/// <returns></returns>
		public bool MakeWafer(List<int> xy)
		{
			// Gridから削除
			Wafer.Children.Clear();
			// 管理用リストから削除
			WaferBorder.Clear();

			Wafer.RowDefinitions.Clear();
			Wafer.ColumnDefinitions.Clear();

			// Grid Definition
			for(int i = 0; i < xy.Count; ++i)
			{
				var rd = new RowDefinition();
				rd.Height = GridLength.Auto;
				Wafer.RowDefinitions.Add(rd);
			}
			for (int i = 0; i < xy.Max(); i++)
			{
				var cd = new ColumnDefinition();
				cd.Width = GridLength.Auto;
				Wafer.ColumnDefinitions.Add(cd);
			}

			// 管理用リストに入れとく
			for(int y = 0; y < xy.Count; ++y)
			{
				var ylist = new List<Border>();
				for (int x = 0; x < xy[y]; ++x)
				{
					Wafer.RowDefinitions.Add(new RowDefinition());
					var newrect = new Border();
					newrect.BorderBrush = Brushes.Black;
					newrect.Height = 10;
					newrect.Width = 10;
					newrect.BorderThickness = new Thickness(1, 1, 1, 1);
					// newrect
					Grid.SetColumn(newrect, x);
					Grid.SetRow(newrect, y);
					ylist.Add(newrect);
				}
				WaferBorder.Add(ylist);
			}

			// Gridに入れる
			WaferBorder.ForEach((y => y.ForEach(x => Wafer.Children.Add(x))));

			return true;
		}

	}
}
