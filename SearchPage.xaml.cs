﻿using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;
using FinalProject.Exceptions;

namespace FinalProject;

// Created for CPRG 211 finale project
// Page search through the books and place them on hold.
// created by Iza Lumpio and Lisa Pokam
// April 25, 2023
public partial class SearchPage : ContentPage
{
    //counter for books selected in this page
    int count = 0;
    //Books for the books to be displayed in this page
    public List<Book> Books = new List<Book>();
    // search result books in the database
    public List<Book> searchResults = new List<Book>();
    // message for when there is no result found
    public string noResult = "No Book found";

    // a list for storing the selected books that are to reserve/put on hold
    public static List<Book> SelectedBooks = new List<Book>();
    public Book selectedBook;

    //exception
    public BookAvailabilityException eBookNotAvailable = new BookAvailabilityException() { };
    public BookNotFoundException eBookNotFound = new BookNotFoundException() { };

    /// <summary>
    /// Search page constructor
    /// </summary>
    public SearchPage()
    {
        //initialize the SearchPage
        InitializeComponent();

        //connect to the database
        LibraryDatabase db = new LibraryDatabase();

        //get all the books in the database and store in a list called books
        Books = db.Select();

        // display those books in the collection view
        listBooks.ItemsSource = Books;
    }


    /// <summary>
    /// adds the book to the list of books to be put on hold
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnToCartClicked(object sender, EventArgs e)
    {

        count++;
        // get the selected item in the collectionview of the search page
        selectedBook = (Book)listBooks.SelectedItem;

        // check if there is as selected item, and they clicked on hold, then put the item in the list of books to be on hold
        if (count == 1 || listBooks.SelectedItem != null)
        {
            // if selected book is currently available display the pop up where you can put it on hold; else, display it is not available
            if (selectedBook.Is_Available)
            {
                bool hold = await DisplayAlert("On Hold", "Do you want to hold", "On hold", "Cancel");


                if (hold)
                {
                    // add the book to the list of books callsed SelectedBooks which are the list of books to be displayed in the onhold/reserve page
                    SelectedBooks.Add(selectedBook);
                    selectedBook.placeHold();  // make book no longer available to be put on hold;
                }
                listBooks.SelectedItem = null;  // after the selected book is added, turn it back to default
            }

            else
            {
                await DisplayAlert("Not Availbale", eBookNotAvailable.Message, "Cancel");
            }
        }
    } 

    /// <summary>
    /// Handles what happens when user types in a book, word, etc.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        LibraryDatabase db = new LibraryDatabase();
        searchResults = db.SearchBook(e.NewTextValue);
        if (searchResults.Count > 0)
        {
            listBooks.ItemsSource = searchResults;
        }
        else
        {
            listBooks.ItemsSource = null;  //display nothing if not found;
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
            DisplayAlert("Alert", eBookNotFound.Message, "Ok");
        }
    }    
}