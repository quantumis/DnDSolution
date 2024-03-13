using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSolution
{
    public class DetailChapterPage : ContentPage
    {
        public DetailChapterPage(int id)
        {
            Title = $"DetailChapterPage №{id}";

            Button menu_button = new Button();
            menu_button.Text = "Menu";
            menu_button.Clicked += async (o, e) => await Navigation.PushAsync(new MainPage(), true);
            Button chapter_button = new Button();
            chapter_button.Text = "Chapter";
            chapter_button.Clicked += async (o, e) => await Navigation.PushAsync(new CommonPage(), true);
            Button library_button = new Button();
            library_button.Text = "Library";
            library_button.Clicked += async (o, e) => await Navigation.PushAsync(new UncommonPage(), true);

            StackLayout Menu = new StackLayout { Children = { menu_button, chapter_button, library_button } };
            Menu.Orientation = StackOrientation.Horizontal;
            Menu.HorizontalOptions = LayoutOptions.Center;
            Menu.Margin = 10;
            Menu.Spacing = 30;

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height=new GridLength(2, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(2, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            grid.Add(Menu, 0, 3);
            Grid.SetColumnSpan(Menu, 3);

            Content = grid;
        }
    }
}
