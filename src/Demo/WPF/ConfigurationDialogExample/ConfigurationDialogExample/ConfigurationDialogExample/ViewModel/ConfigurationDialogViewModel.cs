using System.Collections.ObjectModel;

namespace ConfigurationDialogExample.ViewModel
{
    public class ConfigurationDialogViewModel : ViewModelBase
    {
        private readonly ObservableCollection<object> settings;

        public ObservableCollection<object> Settings
        {
            get { return this.settings; }
        }

        public ConfigurationDialogViewModel()
        {
            this.settings = new ObservableCollection<object>();

            this.settings.Add(new GeneralSettingsViewModel());
            this.settings.Add(new AdvancedSettingsViewModel());
        }
    }
}
