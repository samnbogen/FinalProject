using FinalProject.Entities;

namespace FinalProject;

public partial class ReservePage : ContentPage
{
    int count = 0;

    public ReservePage()
	{
		InitializeComponent();
	}

    Book book = new Book();
    private async void OnReserveClicked(object sender, EventArgs e)
    {
        count++;

        if (count >= 1)
            await DisplayAlert("Read", "Successfully reserved. Pick up the book by " + book.ReserveBook(), "Confirm");

        SemanticScreenReader.Announce(ReserveBtn.Text);
    }

}