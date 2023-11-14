namespace Netflask.Web.Models
{
	public class NewsShow
	{
		private string text;
		private List<News> _news;

		public string Text { get => text; set => text = value; }
		public List<News> News { get => _news; set => _news = value; }
	}
}
