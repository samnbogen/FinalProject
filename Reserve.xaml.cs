using FinalProject.Entities;
using FinalProject.Data;
using FinalProject;
//using static Java.Util.Concurrent.Flow;


namespace FinalProject;

public partial class ReservePage : ContentPage
{
    int count = 0;
    //public List<Book> booksInCart = new List<Book>();
    List<Book> books;

    //private Book _selectedBook;
    public ReservePage() 
    {
        InitializeComponent();

        LibraryDatabase dataRandom = new LibraryDatabase();
        //List<Book> list = dataRandom.SelectABook();
        books = SearchPage.SelectedBooks.ToList();
        // List<string> strings = new List<string>();
        //List<Book> booksInCart = new List<Book>();
        booksInCart.ItemsSource = books;

        

        //foreach (Book book in SearchPage.SelectedBooks)
        //{
        //    //strings.Add(book.Display());
        //    //strings.Remove(book.Is_Available.ToString());
        //    booksInCart.Add(book);
        //}

        //booksInCart.ItemsSource = strings;

        //BindingContext = book;
        //_selectedBook = selectedBook;
        //bookLabel.Text = $"{_selectedBook.Isbn}, {_selectedBook.Title}, {_selectedBook.Genre}, {_selectedBook.Author_FirstName} {_selectedBook.Author_LastName}";


        //List<Book> SelectedBookList = _selectedBook;
        //List<string> strings = new List<string>();

        //foreach (Book book in list)
        //{
        //    strings.Add(book.Display());
        //}

        //listBooks.ItemsSource = strings;


        //_selectedBook = selectedBook;

        //Title = selectedBook.Title;
        //Isbn = selectedBook.Isbn;
        //Author_FirstName = selectedBook.Author_FirstName;
        //Author_LastName = selectedBook.Author_LastName;
        //Publisher = selectedBook.Publisher;
        //Genre = selectedBook.Genre;
    }

    //public static List<Book> SelectedBooks = new List<Book>();

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //}

    //Book book = new Book();
    //public Book selectedBook;

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        count++;

        Book selectedBook = (Book)booksInCart.SelectedItem;


        if (count >= 1 && selectedBook != null)
        {
            bool cancelOnHold = await DisplayAlert("Alert", "Want to cancel hold?", "Cancel hold", "Not now");
           
            if (cancelOnHold)
            {
                books.Remove(selectedBook);
                selectedBook.Is_Available = true;
                booksInCart.ItemsSource = null;
                booksInCart.ItemsSource = books;

            } 

            //booksInCart.ItemsSource = books;
        }
            
        //int i = booksInCart
        //book = SearchPage.SelectedBooks[i];
        //book.Is_Available = true;
        

        //SemanticScreenReader.Announce(ReserveBtn.Text);
    }

   

}