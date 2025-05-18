

namespace RQPlayer;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
        DisplayAlert("Informação", "Play clicado!", "OK"); // Substitua por lógica real depois  
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        DisplayAlert("Informação", "Stop clicado!", "OK"); // Substitua por lógica real depois  
    }
}
