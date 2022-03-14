using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NewsFeed.Core.Models
{
    public class Post : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string _id;
		[JsonProperty("id")]
		public string Id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;

				_id = value;

				HandlePropertyChanged();
			}
		}

		string _postId;
		[JsonProperty("postId")]
		public string PostId
		{
			get => _postId;
			set
			{
				if (_postId == value)
					return;

				_postId = value;

				HandlePropertyChanged();
			}
		}

		string _type;
		[JsonProperty("type")]
		public string Type
		{
			get => _type;
			set
			{
				if (_type == value)
					return;

				_type = value;

				HandlePropertyChanged();
			}
		}

		string _title;
		[JsonProperty("title")]
		public string Title
		{
			get => _title;
			set
			{
				if (_title == value)
					return;

				_title = value;

				HandlePropertyChanged();
			}
		}

		string _content;
		[JsonProperty("content")]
		public string Content
		{
			get => _content;
			set
			{
				if (_content == value)
					return;

				_content = value;

				HandlePropertyChanged();
			}
		}

		string _commentCount;
		[JsonProperty("commentCount")]
		public string CommentCount
		{
			get => _commentCount;
			set
			{
				if (_commentCount == value)
					return;

				_commentCount = value;

				HandlePropertyChanged();
			}
		}

		string _likeCount;
		[JsonProperty("likeCount")]
		public string LikeCount
		{
			get => _likeCount;
			set
			{
				if (_likeCount == value)
					return;

				_likeCount = value;

				HandlePropertyChanged();
			}
		}

		string[] _imagesList;
		[JsonProperty("imagesList")]
		public string[] ImagesList
		{
			get => _imagesList;
			set
			{
				if (_imagesList == value)
					return;

				_imagesList = value;

				HandlePropertyChanged();
			}
		}

		DateTime _dateCreated;
		[JsonProperty("dateCreated")]
		public DateTime DateCreated
		{
			get => _dateCreated;
			set
			{
				if (_dateCreated == value)
					return;

				_dateCreated = value;

				HandlePropertyChanged();
			}
		}

		void HandlePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var eventArgs = new PropertyChangedEventArgs(propertyName);

			PropertyChanged?.Invoke(this, eventArgs);
		}
	}
}
