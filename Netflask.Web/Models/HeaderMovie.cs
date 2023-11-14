namespace Netflask.Web.Models
{
	public class HeaderMovie
	{
		#region Fields
		private string _title;
		private string _description;
		private string _pictureUrl;
		private DateTime _releaseDate;
		private string _directors;
		private double _rating;
		private string _genre;
		private string _categorie;
		#endregion

		#region Properties
		public string Title { get => _title; set => _title = value; }
		public string Description { get => _description; set => _description = value; }
		public string PictureUrl { get => _pictureUrl; set => _pictureUrl = value; }
		public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
		public  string Directors { get => _directors; set => _directors = value; }
		public double Rating { get => _rating; set => _rating = value; }
		public string Genre { get => _genre; set => _genre = value; }
		public string Categorie { get => _categorie; set => _categorie = value; }
		#endregion
	}
}
