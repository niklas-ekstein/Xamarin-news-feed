using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsFeed.Core
{
	public partial class AddPostPage : ContentPage
	{
		//public Monk CurrentItem { get; set; }

		Post1 ToDoItem;

		bool IsNew;
		ItemDetailViewModel ViewModel;

		List<string> PictureList; // = new List<string>();

		string[] myArray = null;
		byte[] imageArray = null;
		string uploadedFilename = "orörd";

		int count = 0;

		string picValue = "orörd";

		//public ObservableCollection<Monk> Monkeys { get; set; } = new ObservableCollection<Monk>();

		//public IEnumerable<string> ImagesList
		//{
		//	get => imagesList;
		//	set => SetProperty(ref imagesList, value);
		//}

		public AddPostPage(Post1 item, bool isNew)
		{
			InitializeComponent();

			ToDoItem = item;
			IsNew = isNew;

			PictureList = new List<string>();

			//ToDoItem.Title = uploadedFilename;

			ViewModel = new ItemDetailViewModel(ToDoItem, IsNew);
			ViewModel.SaveComplete += Handle_SaveComplete;

			BindingContext = ViewModel;
		}

		protected override void OnDisappearing()
		{
			//ToDoItem.Pictures = termsList.ToArray();

			base.OnDisappearing();

			//ViewModel.blobName = uploadedFilename;

			ViewModel.SaveComplete -= Handle_SaveComplete;
		}

		async void Handle_SaveComplete(object sender, EventArgs e)
		{
			await DismissPage();
		}

		protected async void Handle_CancelClicked(object sender, EventArgs e)
		{
			await DismissPage();
		}

		async Task DismissPage()
		{
			if (IsNew)
				await Navigation.PopModalAsync();
			else
				await Navigation.PopAsync();
		}

		async void Button_Clicked(System.Object sender, System.EventArgs e)
		{
			count++;

			//ToDoItem.Username = ToDoItem.PostId + count;

			PictureList.Add(ToDoItem.PostId + count);

			//Monk m = new Monk();

			ToDoItem.ImagesList = PictureList.ToArray();

			Monk m1 = new Monk();

			var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
			{
				Title = "Please pick a photo"
			});

			if (result != null)
			{
				var stream = await result.OpenReadAsync();
				var stream2 = await result.OpenReadAsync();

				using (MemoryStream memory = new MemoryStream())
				{
					//Stream stream1 = photo.GetStream();
					stream.CopyTo(memory);
					imageArray = memory.ToArray();
					m1.ImageArrayMonk = imageArray;
				}

				//Monk m1 = new Monk();
				m1.MonkImage = ImageSource.FromStream(() => { return stream2; });

				ViewModel.Monkeys.Add(m1);

				//m.MonkImage = ImageSource.FromStream(() => { return stream2; });

				//m.MonkImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg";

				//Monkeys.Add(m);
				//imageToUpload.Source = ImageSource.FromStream(() => { return stream2; });
				//imageToUpload.Source = ImageSource.FromStream(() => stream2);
				//imageToUpload2.Source = ImageSource.FromStream(() => stream2);
			}

			//Den som snurrar?
			//activityIndicator.IsRunning = true;

			//DET HÄR LADDAR UPP TILL CLOUDET, metoden skall dock bytas ut för att skicka in ett namn iställte för att få tillbaka ett.
			//uploadedFilename = await AzureStorage.UploadFileAsync(ContainerType.Image, new MemoryStream(imageArray));

			//Den som snurrar?
			//activityIndicator.IsRunning = false;
		}

		void loading_Clicked(System.Object sender, System.EventArgs e)
		{
			this.Content.IsEnabled = false;
		}

		//void Button_Clicked_2(System.Object sender, System.EventArgs e)
		//      {

		//}

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
			
        }
    }
}