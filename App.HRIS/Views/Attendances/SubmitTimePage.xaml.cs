using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Primitives;

namespace App.HRIS.Views.Attendances;

public partial class SubmitTimePage : ContentPage
{
    private ICameraProvider cameraProvider;

    public SubmitTimePage(ICameraProvider cameraProvider)
	{
		InitializeComponent();
        this.cameraProvider = cameraProvider;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await cameraProvider.RefreshAvailableCameras(CancellationToken.None);
        picCamera.SelectedCamera = cameraProvider.AvailableCameras
            .Where(c => c.Position == CameraPosition.Front).FirstOrDefault();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);

        picCamera.MediaCaptured -= picCamera_MediaCaptured;
        picCamera.Handler?.DisconnectHandler();
    }

    private void picCamera_MediaCaptured(object? sender, CommunityToolkit.Maui.Views.MediaCapturedEventArgs e)
    {
        if (Dispatcher.IsDispatchRequired)
        {
            Dispatcher.Dispatch(() => picImage.Source = ImageSource.FromStream(() => e.Media));
            return;
        }

        picImage.Source = ImageSource.FromStream(() => e.Media);
    }

    private async void cameraButton_Clicked(object sender, EventArgs e)
    {
        await picCamera.CaptureImage(CancellationToken.None);
        picCamera.IsVisible = false;
        cameraButton.IsVisible = false;        
        gpsButton.IsVisible = true;       
    }

    private void timeInButton_Clicked(object sender, EventArgs e)
    {
        picCamera.CameraFlashMode = picCamera.CameraFlashMode == CameraFlashMode.Off ?
            CameraFlashMode.On : CameraFlashMode.Off;
    }

    private void timeOutButton_Clicked(object sender, EventArgs e)
    {
        picCamera.ZoomFactor += 0.1f;
    }

    private async void gpsButton_Clicked(object sender, EventArgs e)
    {
        var location = await Geolocation.Default.GetLocationAsync();

        await DisplayAlert("Location", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}", "OK");
    }
}