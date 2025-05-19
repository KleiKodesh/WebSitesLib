using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WpfLib;
using WpfLib.ViewModels;

namespace WebSitesLib
{
    public class WebSitesViewModel : ViewModelBase
    {
        string _jsonFileName = "WebSitesWhitelist.json";
        ObservableCollection<WebAdressModel> _adresses;
        public ObservableCollection<WebAdressModel> Adresses { get => _adresses; set => SetProperty(ref _adresses, value); }

        public RelayCommand EditWhiteListCommand => new RelayCommand(() => ShowWhiteListDialog());

        public WebSitesViewModel() 
        {
            PopulateAdressList();
        }

        void PopulateAdressList()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", _jsonFileName);
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                Adresses = JsonSerializer.Deserialize<ObservableCollection<WebAdressModel>>(json) ?? new ObservableCollection<WebAdressModel>();
            }
        }

        void ShowWhiteListDialog()
        {
            WhiteListDialog dialog = new WhiteListDialog(this);
            dialog.ShowDialog();

            string json = JsonSerializer.Serialize(Adresses);
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _jsonFileName);
            if (File.Exists(jsonPath))
                File.WriteAllText(jsonPath, json);
        }
    }
}
