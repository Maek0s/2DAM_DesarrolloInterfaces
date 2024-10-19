namespace AYUDA.Pages;

public partial class Page5 : ContentPage
{
    Label lblresumen = new Label();

    public Page5()
	{
		InitializeComponent();
        lblgetResumen.Text = "Fruta: " + Page2.fruta + "\nCantidad: " + Page3.cantidad + "\nDireccion: " + Page4.direccion;
        ponerFruta();
    }

    public Page5(Label lblresumen)
    {
        InitializeComponent();
        // this.lblresumen = lblresumen;
        // lblgetResumen.Text = lblresumen.Text;
        //ponerFruta();
    }

    private void ponerFruta()
    {
        String cad = Page2.fruta;

        if (cad.Contains("Manzana")) {
            imgFruta.Source = "manzana.png";
        } else if (cad.Contains("Albaricoque")) {
            imgFruta.Source = "albaricoque.png";
        } else if (cad.Contains("Fresa")) {
            imgFruta.Source = "fresa.png";
        } else if (cad.Contains("Frambuesa")) {
            imgFruta.Source = "frambuesa.png";
        }
    }

    private async void btnAnterior_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}