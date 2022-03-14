using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace NewsFeed.Core
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public string blobName = "itemDetailViewModel";
		bool isNew;

		//ActivityIndicator activityIndicator = new ActivityIndicator { IsRunning = false };

		public ObservableCollection<Monk> Monkeys { get; set; } = new ObservableCollection<Monk>();

		public Monk CurrentItem { get; set; }



		//public ICommand ItemChangedCommand => new Command<Monkey>(ItemChanged);

		public bool IsNew
		{
			get => isNew;
			set => SetProperty(ref isNew, value);
		}

		public Post1 ToDoItem { get; set; }
		public ICommand SaveCommand { get; }

		//public ICommand DeleteCommand; // => new Command<Monk>(RemoveMonkey);
		public ICommand DeleteCommand { get; set; } // => new Command<Monk>(RemoveMonkey);

		public event EventHandler SaveComplete;

		public ItemDetailViewModel(Post1 todo, bool isNew)
		{
			Monkeys.Clear();

			//Monk m1 = new Monk();
			//m1.MonkImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg";
			//Monkeys.Add(m1);

			CurrentItem = Monkeys.FirstOrDefault();//DETTA BARA FUNKA MED USING LINQ
												   //Jag vette fan, detta kanske va bra? många ställen att kolla runt properychanged å current item osv?

			IsNew = isNew;
			ToDoItem = todo;

			SaveCommand = new Command(async () => await ExecuteSaveCommand());
			DeleteCommand = new Command(RemoveMonkey);

			Title = IsNew ? "New To Do" : ToDoItem.PostId;
		}

		async Task ExecuteSaveCommand()
		{
			//Page.IsEnabledProperty = false;

			UserDialogs.Instance.ShowLoading("Loading post..");

			//activityIndicator.IsRunning = true;
			//Foreach Monk.MonkImage azure.blob.add?
			foreach (Monk m in Monkeys)
			{
				string uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Image, new MemoryStream(m.ImageArrayMonk));
			}

			if (IsNew)
				await CosmosDBService.InsertToDoItem(ToDoItem);
			else
				await CosmosDBService.UpdateToDoItem(ToDoItem);

			UserDialogs.Instance.HideLoading();

			//XactivityIndicator.IsRunning = false;

			SaveComplete?.Invoke(this, new EventArgs());
		}

		void RemoveMonkey()
		{
			if (Monkeys.Contains(CurrentItem))
			{
				Monkeys.Remove(CurrentItem);
			}
		}

		//void ItemChanged(Monk item)
		//{
		//	PreviousMonkey = CurrentMonkey;
		//	CurrentMonkey = item;
		//	OnPropertyChanged("PreviousMonkey");
		//	OnPropertyChanged("CurrentMonkey");
		//}
	}
}
