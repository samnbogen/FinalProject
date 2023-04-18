using FinalProject.Data;
using FinalProject.Entities;
using System.Collections;

namespace FinalProject;

public partial class SearchPage : ContentPage 
{
	int count = 0;

	public SearchPage() 
	{
        InitializeComponent();

		LibraryDatabase db= new LibraryDatabase();

		List<Book> listOfBooks = db.Select();
		List<string> books = new List<string>();

		foreach(Book book in listOfBooks)
		{
			books.Add(book.Display());
        }



		booksList.ItemsSource = books;
    }

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	count++;

	//	if (count == 1)
	//		CounterBtn.Text = $"Clicked {count} time";
	//	else
	//		CounterBtn.Text = $"Clicked {count} times";

	//	SemanticScreenReader.Announce(CounterBtn.Text);
	//}
}

