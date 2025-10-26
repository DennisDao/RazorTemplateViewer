using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace RazorTemplateViewer.Views
{
    /// <summary>
    /// Interaction logic for Rendering_2.xaml
    /// </summary>
    public partial class Splash : UserControl
    {
        public Splash()
        {
            InitializeComponent();
            DelayStartAnimation();
            Storyboard sb1 = (Storyboard)this.Resources["MarginAnimation"];
            sb1.Begin();
        }

        private async void DelayStartAnimation()
        {
            await Task.Delay(2000);
            Storyboard blink = (Storyboard)this.Resources["BlinkStoryboard"];
            blink.Begin(line1, true);
            blink.Begin(line2, true);
            blink.Begin(line3, true);
            blink.Begin(line4, true);
            blink.Begin(line5, true);
            blink.Begin(line6, true);
            blink.Begin(line7, true);
            blink.Begin(line8, true);
        }
    }
}
