namespace FinalProject;

public partial class CheckoutPage : ContentPage
{
    int count = 0;

    public CheckoutPage()
	{
		InitializeComponent();
	}
    private async void OnCheckoutClicked(object sender, EventArgs e)
    {
        count++;

        if (count >= 1)
            await DisplayAlert("Checked out", "Successfully checked out", "OK");

        SemanticScreenReader.Announce(CheckOutBtn.Text);
    }

}