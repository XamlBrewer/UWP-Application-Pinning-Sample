using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI.Shell;
using Windows.UI.StartScreen;

namespace Mvvm.Services
{
    public class Pinning
    {
        public async static Task<bool?> IsPinnedToTaskBar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.Shell.TaskbarManager"))
            {
                return await TaskbarManager.GetDefault().IsCurrentAppPinnedAsync();
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool?> RequestPinToTaskBar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.Shell.TaskbarManager"))
            {
                return await TaskbarManager.GetDefault().RequestPinCurrentAppAsync();
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool?> IsPinnedToStartMenu()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
            {
                AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];
                return await StartScreenManager.GetDefault().ContainsAppListEntryAsync(entry);
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool?> RequestPinToStartMenu()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
            {
                AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];
                return await StartScreenManager.GetDefault().RequestAddAppListEntryAsync(entry);
            }
            else
            {
                return null;
            }
        }

        public async static Task<bool> HasSecondaryTiles()
        {
            var tiles = await SecondaryTile.FindAllAsync();
            return tiles.Count > 0;
        }
    }
}
