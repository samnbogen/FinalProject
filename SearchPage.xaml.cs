using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;

namespace FinalProject;

public partial class SearchPage : ContentPage 
{
    int count = 0;

    public List<Book> Books = new List<Book>();
    //public List<string> strings = new List<string>();

    public SearchPage()
    {
        //initialize the SearchPage
        InitializeComponent();

        //connect to the database
        LibraryDatabase db = new LibraryDatabase();

        //get all the books in the database and store in a list called books
        Books = db.Select();
        // Don't include any book.Is_available = false


        // turn the books into a string; may need it later
        //foreach(Book book in Books)
        //{
        //	strings.Add(book.Display());
        //}

        listBooks.ItemsSource = Books;
    }

    // a list for storing the selected books
    public static List<Book> SelectedBooks = new List<Book>();
    //public Book selectedBook;
    //Book book = new Book();


    private async void OnToCartClicked(object sender, EventArgs e)
    {
        count++;
        //selectedBook = e.SelectedItem;
        Book selectedBook = (Book)listBooks.SelectedItem;

        if (count == 1 || listBooks.SelectedItem != null)
        {
            if(selectedBook.Is_Available.Equals(true))
            {
                bool hold = await DisplayAlert("On hold", "Do you want to hold", "On hold","Cancel");
                if(hold)
                {
                    SelectedBooks.Add((Book)listBooks.SelectedItem);
                    selectedBook.Is_Available = false;

                }
                listBooks.SelectedItem = null;
            }

            else
            {
                await DisplayAlert("Alert", "Currently not available", "Cancel");
            }

        }
        //else if (listBooks.SelectedItem == )
        //{

        //}
        //SemanticScreenReader.Announce(ToCartBtn.Text);
    }

    /// <summary>
    /// Handles what happens when user types in a book, word, etc.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        LibraryDatabase db = new LibraryDatabase();
        List<Book> results = db.SearchBook(e.NewTextValue);
        if (results.Count > 0)
        {
            listBooks.ItemsSource = results;
        }
        else
        {
            await DisplayAlert("Alert", "No Book found", "Ok");
        }

    }


    /// <summary>
    /// Handles what happens when user clickes search btn (the magnifying glass icon)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchBtn_Clicked(object sender, EventArgs e)
    {

    }
}

