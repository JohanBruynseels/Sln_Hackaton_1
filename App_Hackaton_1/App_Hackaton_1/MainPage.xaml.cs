using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Hackaton_1
{
    public partial class MainPage : ContentPage
    {
        Label lblKeuze = new Label();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Label lblTitel = new Label();
            lblTitel.VerticalOptions = LayoutOptions.Start;
            lblTitel.Text = "Welkom";

            lblKeuze.VerticalOptions = LayoutOptions.End;
            lblKeuze.Text = "Keuze";

            ListView lstvwKeuzes = new ListView();
            //lstvwKeuzes.ItemsSource = new string[]{
            //  "mono",
            //  "monodroid",
            //  "monotouch",
            //  "monorail",
            //  "monodevelop",
            //  "monotone",
            //  "monopoly",
            //  "monomodal",
            //  "mononucleosis"
            //};

            var collemployees = new ObservableCollection<ClaEmployee>();

            collemployees.Add(new ClaEmployee { DisplayName = "Rob Finnerty" });
            collemployees.Add(new ClaEmployee { DisplayName = "Bill Wrestler" });
            collemployees.Add(new ClaEmployee { DisplayName = "Dr. Geri-Beth Hooper" });
            collemployees.Add(new ClaEmployee { DisplayName = "Dr. Keith Joyce-Purdy" });
            collemployees.Add(new ClaEmployee { DisplayName = "Sheri Spruce" });
            collemployees.Add(new ClaEmployee { DisplayName = "Burt Indybrick" });

            lstvwKeuzes.ItemsSource = collemployees;

            //DataTemplate tmpldatNaam = new DataTemplate();

            lstvwKeuzes.ItemTemplate = new DataTemplate (() =>
                {
                    Label lblNaam = new Label();
                    lblNaam.SetBinding(Label.TextProperty, "DisplayName");

                    return new ViewCell { View = lblNaam };
                });

            lstvwKeuzes.ItemSelected += LstvwKeuzes_ItemSelected;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    lblTitel,
                    lstvwKeuzes,
                    lblKeuze
                }
            };

        }

        private void LstvwKeuzes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lstKeuzelijst = (ListView)sender;
            lblKeuze.Text = ((ClaEmployee)(lstKeuzelijst.SelectedItem)).DisplayName;

            //throw new NotImplementedException();
        }
    }
}
