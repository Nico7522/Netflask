namespace Netflask.Web.Models
{
	public class News
	{
		private string _title;
		private string _description;
		private DateTime _releaseDate;

		public string Title { get => _title; set => _title = value; }
		public string Description { get => _description; set => _description = value; }
		public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
	}
}
