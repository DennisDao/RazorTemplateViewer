using RazorTemplateViewer.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using RazorTemplateViewer.ViewModels.Home;

namespace RazorTemplateViewer.ViewModels.MainWindow
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Public properties
        /// <summary>
        /// The current view of the application
        /// </summary>
        public BaseViewModel CurrentView { get; set; }

        /// <summary>
        /// Relay command to change the window state Maximized
        /// </summary>
        public ICommand MaximizedOrNormalWindowCommand { get; set; }

        /// <summary>
        /// Relay command to change the window state Minimized
        /// </summary>
        public ICommand MinimizedWindowCommand { get; set; }

        /// <summary>
        /// Relay command to change the window state Normal
        /// </summary>
        public ICommand NormalWindowCommand { get; set; }

        /// <summary>
        /// Relay command to change the window state Minimized
        /// </summary>
        public ICommand ExitAppCommand { get; set; }

        /// <summary>
        /// The main window of the application
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// The resize state of the main window
        /// </summary>
        public ResizeMode ResizeMode { get; set; }

        /// <summary>
        /// The window curvature
        /// </summary>
        public CornerRadius TitleBarCornerRadius { get; set; } = new CornerRadius(10, 10, 0, 0);

        /// <summary>
        /// The window width
        /// </summary>
        public int WindowWidth { get; set; } = 1600;

        /// <summary>
        /// The window height
        /// </summary>
        public int WindowHeight { get; set; } = 1200;

        /// <summary>
        /// The window gutter width
        /// </summary>
        public int WindowGutterWidth { get; set; } = 10;

        /// <summary>
        /// Flag to determine whether the window is maximized
        /// </summary>
        public bool IsWindowMaximized { get; set; } = false;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// 
        public MainWindowViewModel(Window window)
        {
            Window = window;
            CurrentView = new SplashViewModel();
            SetupCommand();
            ShowHomeScreen();
        }

        private async void ShowHomeScreen()
        {
            await Task.Delay(2000);
            CurrentView = new HomeViewModel();
        }
 

    
        public void SetupCommand()
        {
            MaximizedOrNormalWindowCommand = new RelayCommand(() => {
                if (Window.WindowState == WindowState.Normal)
                {
                    WindowGutterWidth = 10;
                    TitleBarCornerRadius = new CornerRadius(10, 10, 0, 0);
                    Window.WindowState = WindowState.Maximized;
                    IsWindowMaximized = true;
                }
                else
                {
                    WindowGutterWidth = 0;
                    TitleBarCornerRadius = new CornerRadius(0, 0, 0, 0);
                    Window.WindowState = WindowState.Normal;
                    IsWindowMaximized = false;
                }
            });

            MinimizedWindowCommand = new RelayCommand(() =>
            {
                WindowGutterWidth = 10;
                TitleBarCornerRadius = new CornerRadius(10, 10, 0, 0);
                Window.WindowState = WindowState.Minimized;
            });


            ExitAppCommand = new RelayCommand(() => Window.Close());
        }
        #endregion
    }
}
