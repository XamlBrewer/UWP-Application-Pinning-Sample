using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using XamlBrewer.Uwp.ApplicationPinningSample;

namespace Mvvm.Services
{
    public class Activation
    {
        public async Task LaunchAsync(LaunchActivatedEventArgs e)
        {
            // Custom pre-launch service calls.
            await PreLaunchAsync(e);

            // Navigate
            // Secondary Tile Id is in e.Arguments, and passed to page as e.Parameter in OnNavigatedTo.
            Window.Current.EnsureRootFrame().NavigateIfAppropriate(typeof(Shell), e.Arguments).Activate();

            // Custom post-launch service calls.
            await PostLaunchAsync(e);
        }

        /// <summary>
        /// Application Services before the launch.
        /// </summary>
        private async Task PreLaunchAsync(LaunchActivatedEventArgs e)
        {
            Theme.ApplyToContainer();

            await Task.CompletedTask;
        }

        /// <summary>
        /// Application Services after the launch.
        /// </summary>
        /// <returns></returns>
        private async Task PostLaunchAsync(LaunchActivatedEventArgs e)
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = false;

            await Task.CompletedTask;
        }
    }
}
