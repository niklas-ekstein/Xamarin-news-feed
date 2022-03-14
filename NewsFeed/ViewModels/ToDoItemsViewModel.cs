using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
namespace NewsFeed.Core
{
	public class ToDoItemsViewModel : BaseViewModel
	{
		List<Post1> todoItems;
		public List<Post1> ToDoItems { get => todoItems; set => SetProperty(ref todoItems, value); }

		public ICommand RefreshCommand { get; }
		//public ICommand CompleteCommand { get; }

		public ToDoItemsViewModel()
		{
			ToDoItems = new List<Post1>();
			RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
			//CompleteCommand = new Command<Post1>(async (item) => await ExecuteCompleteCommand(item));
		}

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				ToDoItems = await CosmosDBService.GetToDoItems();
			}
			finally
			{
				IsBusy = false;
			}
		}

		//async Task ExecuteCompleteCommand(Post1 item)
		//{
		//	if (IsBusy)
		//		return;

		//	IsBusy = true;

		//	try
		//	{
		//		await CosmosDBService.CompleteToDoItem(item);
		//		ToDoItems = await CosmosDBService.GetToDoItems();
		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}
		//}
	}
}
