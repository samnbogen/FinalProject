using FinalProject.Entities;

namespace FinalProject;

public partial class CheckoutPage : ContentPage
{
    int count = 0;

    public CheckoutPage()
	{
		InitializeComponent();
	}

    Book book = new Book();
    private async void OnCheckoutClicked(object sender, EventArgs e)
    {
        count++;

        if (count >= 1)
            await DisplayAlert("Checked out", "Successfully checked out. Return the book by " + book.CheckOut(), "Confirm");

        SemanticScreenReader.Announce(CheckOutBtn.Text);
    }

}