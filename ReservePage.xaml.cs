using FinalProject.Entities;
using FinalProject.Data;
using FinalProject;


namespace FinalProject;



public partial class ReservePage : ContentPage
{
    int count = 0;
    //this list will hold the books selected in the searchpage; will be displayed in collectionview of this page
    List<Book> books = new List<Book>();

    /// <summary>
    /// ReservePage Constructor
    /// </summary>
    public ReservePage()
    {
        InitializeComponent();

        // connect to library database
        LibraryDatabase dataRandom = new LibraryDatabase();

        // assign the books selected in the search page
        books = SearchPage.SelectedBooks.ToList();
        booksInCart.ItemsSource = books;

    }

    /// <summary>
    /// cencels the selected book, removes it from the list of books to show in the collectionview of this page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // a counter for keeping track of selected books in this page
        count++;
        // get the selected item in the collection view named booksInCart
        Book selectedBook = (Book)booksInCart.SelectedItem;

        // checks if there is a selected book that is to be cancelled
        if (count >= 1 && selectedBook != null)
        {
            // get the bool result of a popup alert; if bool is true then they want to cancel the book on hold
            bool cancelOnHold = await DisplayAlert("Alert", "Want to cancel hold?", "Cancel hold", "Not now");

            if (cancelOnHold)
            {
                // remove selected book from books currently on display in this page
                books.Remove(selectedBook);
                selectedBook.Is_Available = true;
                // trick: to update the collectionview list of books; make it null then reassign to the new list of books in which the canceled book is removed
                booksInCart.ItemsSource = null;
                booksInCart.ItemsSource = books;

            }
        }
    }

}