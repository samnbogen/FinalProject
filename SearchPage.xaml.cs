using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;

namespace FinalProject;

public partial class SearchPage : ContentPage 
{
	//int count = 0;

	public SearchPage() 
	{
        InitializeComponent(); 

		LibraryDatabase dta= new LibraryDatabase();

		List<Book> list = dta.Select(); 
		List<string> strings = new List<string>();

		foreach(Book book in list)
		{
			strings.Add(book.Display());
		}

		listBook.ItemsSource = strings;
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

