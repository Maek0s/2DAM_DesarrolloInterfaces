namespace AYUDA.Pages;

public partial class Page2 : ContentPage
{
    public static String fruta = "";

	public Page2()
	{
		InitializeComponent();
        lWarning.IsVisible = false;
	}

    private async void btnAnterior_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
        if (fruta != "")
        {
            //lblresumen.Text = "Fruta: " + fruta + "\n";
            //await Navigation.PushAsync(new Page3(lblresumen));
            await Navigation.PushAsync(new Page3());
        } else
        {
            lWarning.IsVisible = true;
        }
        
    }

    private void pFruta_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            fruta = (string)picker.ItemsSource[selectedIndex];
        }
    }
}