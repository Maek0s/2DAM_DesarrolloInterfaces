namespace AYUDA.Pages;

public partial class Page3 : ContentPage
{
    Label lblresumen = new Label();
    public static String cantidad = "";

    public Page3()
	{
		InitializeComponent();
	}

    public Page3(Label lblresumen)
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
        //lblresumen.Text = lblresumen.Text + "Cantidad: " + lNum.Text;
        cantidad = lNum.Text;
        await Navigation.PushAsync(new Page4());
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (int.Parse(lNum.Text) > 1)
        {
            lNum.Text = (int.Parse(lNum.Text) - 1).ToString();
        }
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        lNum.Text = (int.Parse(lNum.Text) + 1).ToString();
    }
}