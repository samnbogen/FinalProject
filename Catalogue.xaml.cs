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
    
    List<string> string1 = new List<string>();
    List<string> string2 = new List<string>();
    List<string> string3 = new List<string>();
    List<string> string4 = new List<string>();
    List<string> string5 = new List<string>();
    List<string> string6 = new List<string>();
    public CataloguePage()
	{
		InitializeComponent();

        LibraryDatabase dta = new LibraryDatabase();

        List<Book> list = dta.Select();


        foreach (Book book in list)
        {
            if (book.Genre == "Fantasy")
            {
                string1.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);               
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Science Fiction")
            {
                string2.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);                
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Fiction")
            {
                string3.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Satire")
            {
                string4.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Romance")
            {
                string5.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }

        foreach (Book book in list)
        {
            if (book.Genre == "Mystery")
            {
                string6.Add(book.Title + " By " + book.Author_FirstName + book.Author_LastName);
            }
        }           

    }
      
        

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            genreLabel.Text = picker.Items[selectedIndex];
            if (picker.SelectedIndex == 0)
            {
                spot3.ItemsSource = string1;
            }
            if (picker.SelectedIndex == 1)
            {
                spot3.ItemsSource = string2;
            }
            if (picker.SelectedIndex == 2)
            {
                spot3.ItemsSource = string3;
            }
            if (picker.SelectedIndex == 3)
            {
                spot3.ItemsSource = string4;
            }
            if (picker.SelectedIndex == 4)
            {
                spot3.ItemsSource = string5;
            }
            if (picker.SelectedIndex == 5)
            {
                spot3.ItemsSource = string6;
            }

        }
    }
}