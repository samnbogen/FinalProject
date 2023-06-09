namespace FinalProject;
using FinalProject.Entities;
using System.Collections;
using FinalProject.Data;

// Created for CPRG 211 finale project
// Page to show available books by genre
// created by Samantha Bogen
// April 25, 2023
public partial class CataloguePage : ContentPage
{
    public CataloguePage()
	{
		InitializeComponent();

        //Setting the picker to start on the first item
        genre.SelectedIndex = 0;
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        // getting the index of the selected item in the picker
        int selectedIndex = genre.SelectedIndex;

        //getting what it says on the pcikers selected index
        string name = genre.Items[selectedIndex];

        if (selectedIndex != -1) 
        {
            //setting up the database
            LibraryDatabase db = new();

            //searching the database for books that match the selected genre from the picker
            List<Book> results = db.SearchGenre(name);

            //setting the book results to a list on the xaml page
            booklist.ItemsSource = results;

            //changing the picture based on what the genre is
            foreach (Book book in results)
            {
                if (book.Genre == "Fantasy")
                genreImage.Source = "fantasy.png";

                if (book.Genre == "Fiction")
                genreImage.Source = "fiction.png";

                if (book.Genre == "Mystery")
                genreImage.Source = "mystery.png";

                if (book.Genre == "Science Fiction")
                genreImage.Source = "scifi.png";

                if (book.Genre == "Satire")
                genreImage.Source = "satire.png";

                if (book.Genre == "Romance")
                genreImage.Source = "romance.png";                
            }            
        }  
    }
}