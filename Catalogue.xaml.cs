using FinalProject.Entities;
namespace FinalProject;
using FinalProject.Data;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
//using Windows.Media.Miracast;
//using Windows.Services.Maps.LocalSearch;

public partial class CataloguePage : ContentPage
{
    //create a string for every genre
    List<string> stringFantasy = new List<string>();
    List<string> stringSciFi = new List<string>();
    List<string> stringFiction = new List<string>();
    List<string> stringSatire = new List<string>();
    List<string> stringRomance = new List<string>();
    List<string> stringMystery = new List<string>();

    
    public List<Book> Books = new List<Book>();
    public CataloguePage()
	{
		InitializeComponent();

        genre.SelectedIndex = 1;

        //creating a list for the database
        LibraryDatabase dta = new LibraryDatabase();
        List<Book> list = dta.Select();
    }            

    public static List<Book> SelectedBooks = new List<Book>();
    public Book selectedBook;

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        string name = picker.Items[selectedIndex];

        //adding the selected genre to Label 
        genreLabel.Text = picker.Items[selectedIndex];

        if (selectedIndex != -1) 
        {
            LibraryDatabase db = new LibraryDatabase();
            List<Book> results = db.SearchGenre(name);
            spot3.ItemsSource = results;

            foreach (Book book in results)
            {
                if (book.Genre == "Fantasy")
                myImage.Source = "fantasy.png";

                if (book.Genre == "Fiction")
                myImage.Source = "fiction.png";

                if (book.Genre == "Mystery")
                myImage.Source = "mystery.png";

                if (book.Genre == "Science Fiction")
                myImage.Source = "scifi.png";

                if (book.Genre == "Satire")
                myImage.Source = "satire.png";

                if (book.Genre == "Romance")
                myImage.Source = "romance.png";
                
            }
            
        }  
    }
}