using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace NewsFeed.Core
{
	public class CompletedItemsViewModel : BaseViewModel
	{
		List<Post1> completedToDos;
		public List<Post1> CompletedToDos { get => completedToDos; set => SetProperty(ref completedToDos, value); }

		public ICommand RefreshCommand { get; }

		public CompletedItemsViewModel()
		{
			//RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
			Title = "Completed";
		}

		//async Task ExecuteRefreshCommand()
		//{
		//	if (IsBusy)
		//		return;

		//	IsBusy = true;

		//	try
		//	{
		//		CompletedToDos = await CosmosDBService.GetCompletedToDoItems();
		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}
		//}
	}
}
