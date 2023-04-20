using FinalProject.Entities;
namespace FinalProject;
using FinalProject.Data;
using FinalProject.ViewModel;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

public partial class CataloguePage : ContentPage
{
    //create a string for every genre
    List<string> stringFantasy = new List<string>();
    List<string> stringSciFi = new List<string>();
    List<string> stringFiction = new List<string>();
    List<string> stringSatire = new List<string>();
    List<string> stringRomance = new List<string>();
    List<string> stringMystery = new List<string>();
    public CataloguePage()
	{
		InitializeComponent();

        //creating a list for the database
        LibraryDatabase dta = new LibraryDatabase();
        List<Book> list = dta.Select();

        //populating each list with the appropriate genre
        foreach (Book book in list)
        {
            if (book.Genre == "Fantasy")
            {
                stringFantasy.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);               
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Science Fiction")
            {
                stringSciFi.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);                
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Fiction")
            {
                stringFiction.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Satire")
            {
                stringSatire.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Romance")
            {
                stringRomance.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Mystery")
            {
                stringMystery.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        } 
    }      
        

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {            
            //adding the selected genre to Label 
            genreLabel.Text = picker.Items[selectedIndex];
            
            //checking the index of the selected genre and giving the appropriate list for it
            if (picker.SelectedIndex == 0)
            {
                spot3.ItemsSource = stringFantasy;
            }
            if (picker.SelectedIndex == 1)
            {
                spot3.ItemsSource = stringSciFi;
            }
            if (picker.SelectedIndex == 2)
            {
                spot3.ItemsSource = stringFiction;
            }
            if (picker.SelectedIndex == 3)
            {
                spot3.ItemsSource = stringSatire;
            }
            if (picker.SelectedIndex == 4)
            {
                spot3.ItemsSource = stringRomance;
            }
            if (picker.SelectedIndex == 5)
            {
                spot3.ItemsSource = stringMystery;
            }
        }
    }
}