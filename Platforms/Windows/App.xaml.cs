using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

using Windows.Graphics;

using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Sofia_s_Ladybugs.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            SetWindowBehaviour();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /// <summary>
        /// Configures the window behavior by setting its size, positioning it at the center of the screen,  
        /// and disabling resizing and maximizing(bugged).
        /// </summary>
        private static void SetWindowBehaviour()
        {
            WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                var width = 500;
                var height = 720;

                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();

                var customWindowHandler = WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId = Win32Interop.GetWindowIdFromWindow(customWindowHandler);
                AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

                double screenWidth = DeviceDisplay.MainDisplayInfo.Width;
                double screenHeight = DeviceDisplay.MainDisplayInfo.Height;

                appWindow.MoveAndResize(new RectInt32((int)(screenWidth / 2 - width / 2), (int)(screenHeight / 2 - height / 2), width, height));

                var titleBar = handler.PlatformView.GetAppWindow();
                if (titleBar != null)
                {
                    if (titleBar.Presenter is OverlappedPresenter presenter)
                    {
                        presenter.IsResizable = false;
                        presenter.IsMaximizable = false;
                    }
                }
            });
        }
    }
}
