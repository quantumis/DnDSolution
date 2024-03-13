using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.StyleSheets;
using System.Reflection;

namespace DnDSolution
{
    public class CommonPage : ContentPage
    {
        public CommonPage()
        {
            this.Resources.Add(StyleSheet.FromResource
                    ("Resources/Styles/mystyles.css", IntrospectionExtensions.GetTypeInfo(typeof(CommonPage)).Assembly));
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
                }
            };

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

            grid.Add(Menu, 0, 3);
            Grid.SetColumnSpan(Menu, 3);

            Label label = new Label { Text = "Ваши персонажи", FontSize = 18, VerticalOptions=LayoutOptions.Center, HorizontalOptions=LayoutOptions.Center };
            grid.Add(label, 0, 0);
            Grid.SetColumnSpan(label, 3);

            TableView tableView = new TableView
            {
                Intent = TableIntent.Data,
                RowHeight = 50,
                Root = new TableRoot()
            };

            TableSection mainsection = new TableSection();
            for (int i = 0; i < 20; i++)
            {
                Grid table_row = new Grid {
                    RowDefinitions =
                            {
                                new RowDefinition{ Height=new GridLength(1, GridUnitType.Star) }
                            },
                    ColumnDefinitions =
                            {
                                new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star) },
                                new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
                            }
                };

                StackLayout left_side = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Start,
                    Children = {
                        new Label {
                            Text = $"Персонаж №{i+1}", FontSize=18
                        },
                        new Label {
                            Text = "Краткое описание", FontSize=12, Opacity=0.75
                        }
                    }
                };
                ImageButton right_side = new ImageButton { Source = "can.png", HorizontalOptions = LayoutOptions.End};
                right_side.Clicked += toTrashButtonClick;

                table_row.Add(left_side, 0, 0);
                table_row.Add(right_side, 1, 0);

                ViewCell cell = new ViewCell { View = table_row };
                cell.Tapped += async (o, e) => await Navigation.PushAsync(new DetailChapterPage(i), true);

                mainsection.Add( cell );
            }

            tableView.Root.Add(mainsection);

            ScrollView scrollView = new ScrollView { Content = tableView, Padding=20};
            grid.Add(scrollView, 0, 1);
            Grid.SetColumnSpan(scrollView, 3);
            Grid.SetRowSpan(scrollView, 2);

            Content = grid;
        }

        private async void toTrashButtonClick(object? sender, EventArgs e)
        {
            if (await this.DisplayAlert("Удаление Персонажа",
                                        $"Вы действительно хотите удалить этого персонажа?",
                                        "Да", "Нет"))
            {
                try
                {
                    //Удаление записи
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", "Что-то пошло не так", "Ок");
                }
            }
        }
    }
}
