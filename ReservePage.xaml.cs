using FinalProject.Entities;
using FinalProject.Data;
using FinalProject;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FinalProject;

public partial class ReservePage : ContentPage
{
    //creating a list for the books
    List<Book> books;

    public ReservePage()
    {
        InitializeComponent();

        //getting books selected on the Search Page        
        books = SearchPage.SelectedBooks.ToList();
        
        //putting those books in a list
        booksInCart.ItemsSource = books;      
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        //getting the selected item
        Book selectedBook = (Book)booksInCart.SelectedItem;

        if (selectedBook != null)
        {
            //asking the user if they want to cancel their hold
            bool cancelOnHold = await DisplayAlert("Alert", "Want to cancel hold?", "Cancel hold", "Not now");

            if (cancelOnHold)
            {
                //removing the book from the list and changing it's status
                books.Remove(selectedBook);
                selectedBook.cancelHold();
                booksInCart.ItemsSource = null;
                booksInCart.ItemsSource = books;
            }
        }
    }
}