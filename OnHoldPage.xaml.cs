using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;
using System.Collections.Generic;

namespace FinalProject;

public partial class OnHoldPage : ContentPage
{
    public List<Book> Books = new List<Book>();
    public OnHoldPage()
    {
        InitializeComponent();               

        LibraryDatabase dta = new LibraryDatabase();
        List<Book> list = dta.Select();

        List<Book> books = new List<Book>();
        books = SearchPage.SelectedBooks; 

        List<string> string2 = new List<string>();
        foreach (Book book in books)
        {
            if (book.Is_Available == false)
            {
                string2.Add(book.Title);
            }
        }

        onholdlist.ItemsSource = string2;

    }

    private void onholdlist_BindingContextChanged(object sender, EventArgs e)
    {
        
    }
}