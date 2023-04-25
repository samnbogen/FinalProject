using FinalProject.Entities;
using FinalProject.Data;
using FinalProject;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace FinalProject;

// Created for CPRG 211 finale project
// Page to show books that are onhold and gives the user a way to cancel the hold
// created by Sohee Ryu
// April 25, 2023

public partial class ReservePage : ContentPage
{
    //creating a list for the books
    List<Book> books;

    public ReservePage()
    {
        InitializeComponent();
    }

    //refreshes the list every time the page loads
    protected override async void OnAppearing()
    {
        //waits for us to navigate back
        await Shell.Current.GoToAsync("..");

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

                //remove book from the list on the search page
                SearchPage.SelectedBooks.Remove(selectedBook);

                //cancels the hold status
                selectedBook.cancelHold();
                booksInCart.ItemsSource = null;
                booksInCart.ItemsSource = books;
            }
        }
    }
}