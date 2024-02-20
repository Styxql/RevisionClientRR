using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using RevisionClient.Models;
using RevisionClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionClient.ViewsModels
{
    public class PiloteViewModel:ObservableObject
    {
        public IRelayCommand BtnSearch { get; }
        public WSService Service { get; }

        private Pilote pilote;
        public Pilote Pilote
        {
            get { return pilote; }
            set
            {
                pilote = value;
                OnPropertyChanged();
            }
        }


        public PiloteViewModel()
        {
            Pilote = new Pilote();
            BtnSearch = new RelayCommand(ActionAddMusique);
            Service=new WSService("https://localhost:7259/api/");
            

        }




        public async void ActionAddMusique()
        {
            bool res;

            // Utilisation de l'instance de service créée dans le constructeur
            res = await Service.PostSerieAsync(this.Pilote);
            if (!res)
            {
                ContentDialog noApi = new ContentDialog
                {
                    Title = "marche pas",
                    Content = "marche pas",
                    CloseButtonText = "OK"

                };
                noApi.XamlRoot = App.MainRoot.XamlRoot;

                ContentDialogResult result = await noApi.ShowAsync();
            }
        }
    }
}
