using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsFeed.Core
{
	public partial class RemovedPostPage : ContentPage
	{
		CompletedItemsViewModel ViewModel;
		public RemovedPostPage()
		{
			InitializeComponent();

			ViewModel = new CompletedItemsViewModel();
			BindingContext = ViewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.RefreshCommand.Execute(null);
		}
	}
}
