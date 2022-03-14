using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsFeed.Core
{
    public partial class NewsFeedPage : ContentPage
    {
        ToDoItemsViewModel vm;

        public NewsFeedPage()
        {
            InitializeComponent();

            vm = new ToDoItemsViewModel();
            BindingContext = vm;

            
            vm.Title = "News feed";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }

        protected async void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as Post1;

            if (todoItem == null)
                return;

            await Navigation.PushAsync(new AddPostPage(todoItem, false));
        }

        protected async void AddNewClicked(object sender, EventArgs e)
        {
            var toDo = new Post1();
            var todoPage = new AddPostPage(toDo, true);

            await Navigation.PushModalAsync(new NavigationPage(todoPage));
        }
    }
}
