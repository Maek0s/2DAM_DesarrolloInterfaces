namespace AYUDA.Pages;

public partial class Page4 : ContentPage
{
    Label lblresumen = new Label();
    public static String direccion = "";

    public Page4()
	{
		InitializeComponent();
	}

    public Page4(Label lblresumen)
    {
        InitializeComponent();
        this.lblresumen = lblresumen;
    }

    private async void btnAnterior_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
        if (entDireccion.Text != "")
        {
            //lblresumen.Text = lblresumen.Text + "\nDireccion: " + entDireccion.Text;
            direccion = entDireccion.Text;
            await Navigation.PushAsync(new Page5());
        }
    }
}