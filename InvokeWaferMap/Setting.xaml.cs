using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace InvokeWaferMap
{
	public enum View
	{
		One,
		Two,
		Three,
		Four
	}

	internal class ListView
	{

		public string Owner { get; set; }
		public View View { get; set; }

		public ListView(string owner, View view)
		{
			Owner = owner;
			View = view;
		}
	}

	internal class TreeLists : INotifyPropertyChanged, INotifyCollectionChanged
	{
		public bool? IsChecked
		{ get => _IsChecked;
			set
			{
				if (_IsChecked == value)
					return;
				_IsChecked = value;
				RaisePropertyChanged();
			}
		}
		private bool? _IsChecked;

		public string DisplayName
		{ get => _DisplayName;
			set
			{
				if (_DisplayName == value)
					return;
				_DisplayName = value;
				RaisePropertyChanged();
			}
		}
		private string _DisplayName = "";

		public ObservableCollection<TreeLists> Childs { get; set; } = new ObservableCollection<TreeLists>();

		public TreeLists()
		{
			Childs.CollectionChanged += CollectionChanged;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	internal class TreeNode
	{

	}

	/// <summary>
	/// Setting.xaml の相互作用ロジック
	/// </summary>
	public partial class Setting : Window
	{
		private Dictionary<View, string> ValueDictionaly = new Dictionary<View, string>()
		{
			{View.One, "a"},
			{View.Two, "b"},
			{View.Three, "c"},
			{View.Four, "d"}
		};

		internal class BindingItem
		{
			public string Title { get; set; }
			public string SubTitle { get; set; }
			public ObservableCollection<ListView> DataGridSource { get; set; } = new ObservableCollection<ListView>();
		}

		private ObservableCollection<ListView> listViews = new ObservableCollection<ListView>();

		private ObservableCollection<TreeLists> TreeLists = new ObservableCollection<TreeLists>();

		private ObservableCollection<BindingItem> itemControls = new ObservableCollection<BindingItem>();

		public Setting()
		{
			InitializeComponent();

			var lv = new ListView("aa", View.Four);
			listViews.Add(lv);

			Summary.ItemsSource = listViews;
			ViewCombo.ItemsSource = ValueDictionaly;

			var list = new InvokeWaferMap.TreeLists() { DisplayName = "hoge" };
			var list2 = new InvokeWaferMap.TreeLists() { DisplayName = "hoge" };
			list.Childs.Add(list2);
			var list3 = new InvokeWaferMap.TreeLists() { DisplayName = "hoge" };
			list.Childs.Add(list3);
			TreeLists.Add(list);

			var item1 = new BindingItem() { Title = "hoge1", SubTitle = "hage1" };
			item1.DataGridSource.Add(lv);
			var item2 = new BindingItem() { Title = "hoge2", SubTitle = "hage2" };
			item2.DataGridSource.Add(lv);
			itemControls.Add(item1);
			itemControls.Add(item2);

			this.TreeView.ItemsSource = TreeLists;
			this.BindingItemControl.ItemsSource = itemControls;

			DataContext = this;
		}
	}
}
