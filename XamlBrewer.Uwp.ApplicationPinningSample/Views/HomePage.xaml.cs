using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.ApplicationPinningSample
{
    public sealed partial class HomePage : Page
    {
        private string navigationParameter = string.Empty;

        public HomePage()
        {
            this.InitializeComponent();
        }

        public string NavigationParameter => navigationParameter;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if ((e != null) && (e.Parameter != null))
            {
                navigationParameter = e.Parameter.ToString();
            }

            base.OnNavigatedTo(e);
        }
    }
}
