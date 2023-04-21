using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;

namespace FinalProject;

public partial class SearchPage : ContentPage 
{
    int count = 0;

    public List<Book> Books = new List<Book>();
    public List<Book> searchResults = new List<Book>();
    public string noResult = "No Book found";

    public SearchPage()
    {
        //initialize the SearchPage
        InitializeComponent();

        //connect to the database
        LibraryDatabase db = new LibraryDatabase();

        //get all the books in the database and store in a list called books
        Books = db.Select();

        // turn the books into a string; may need it later
        //foreach(Book book in Books)
        //{
        //	strings.Add(book.Display());
        //}

        listBooks.ItemsSource = Books;
    }

    // a list for storing the selected books
    public static List<Book> SelectedBooks = new List<Book>();
    public Book selectedBook;



    private async void OnToCartClicked(object sender, EventArgs e)
    {
        count++;
        //selectedBook = e.SelectedItem;

        if (count == 1 || listBooks.SelectedItem != null)
        {
            //SelectedBooks.Add((Book)listBooks.SelectedItem);

            bool hold = await DisplayAlert("On Hold", "Do you want to hold", "On hold", "Cancel");
            if (hold)
            {
                SelectedBooks.Add((Book)listBooks.SelectedItem);
            }

            //SearchPage.SelectedBooks = SelectedBooks;

            listBooks.SelectedItem = null;
        }
        //else if (listBooks.SelectedItem == )
        //{

        //}
        //SemanticScreenReader.Announce(ToCartBtn.Text);
        //book.placeHold();
    }

    /// <summary>
    /// Handles what happens when user types in a book, word, etc.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        LibraryDatabase db = new LibraryDatabase();
        searchResults = db.SearchBook(e.NewTextValue);
        if (searchResults.Count > 0)
        {
            listBooks.ItemsSource = searchResults;
        }
        else
        {
            listBooks.ItemsSource=null;  //display nothing if not found;
        }

    }


    /// <summary>
    /// Handles what happens when user clickes search btn (the magnifying glass icon)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
       
        if (searchResults.Count > 0)
        {
            listBooks.ItemsSource = searchResults;
        }
        else
        {
            DisplayAlert("Alert", noResult, "Ok");

        }
    }
}

