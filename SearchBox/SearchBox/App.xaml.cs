using SearchBox.Code;
using SearchBox.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SearchBox
{
    public partial class App : Application
    {
        Label resultLabel;
        SearchBar searchBar;
        StackLayout resultPart;
        // test
        //Label lb_title;
        //Label lb_description;
        //Label lb_district;
        //Label lb_image;
        //Label lb_district;
        //Label lb_city;
        //Label lb_content;

        //

        public App()
        {
            InitializeComponent();

            // create label
            resultLabel = new Label
            {
                Text = "Result is here!",
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25
            };
            // create label
            //lb_title = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //lb_description = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //lb_district = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //lb_image = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //lb_city = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //lb_content = new Label
            //{
            //    HorizontalTextAlignment = TextAlignment.Center,
            //    Text = "",
            //    FontSize = 20
            //};
            //
            resultPart = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,

                Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5)
            };

            // create search bar
            searchBar = new SearchBar
            {
                Placeholder = "Enter keyword: ",
                SearchCommand = new Command(async () =>
                {
                    //resultLabel.Text = "Result: " + searchBar.Text + " is what you want.";
                    string user_input = searchBar.Text;
                    SearchBoxModel model = new SearchBoxModel(user_input);
                    model.result = await model.getData();

                    resultLabel.Text = "Total matchs: ("+ model.result.Count() + ")";
                    resultPart.Children.Clear();
                    foreach (var item in model.result)
                    {
                        string title = "title: " + item.title;
                        string description = "description: " + item.description;
                        string district = "district: " + item.district;
                        string image = "image: " + item.image;

                        Label lb_result_title = new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = title,
                            FontSize = 16
                        };
                        Label lb_result_description = new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = description,
                            FontSize = 14
                        };
                        Label lb_result_district = new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = district,
                            FontSize = 14
                        };
                        Label lb_result_image = new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = image,
                            FontSize = 14
                        };

                        resultPart.Children.Add(lb_result_title);
                        resultPart.Children.Add(lb_result_district);
                        resultPart.Children.Add(lb_result_description);
                        resultPart.Children.Add(lb_result_image);

                    }

                    //lb_user.Text = "user: " + model.result.user;
                    //lb_postdate.Text = "Post date: " + model.result.post_date;
                    //lb_message.Text = "Message:  " + model.result.message;

                    

                    // add label to resultPart

                    //resultPart.Children.Add(lb_user);
                    //resultPart.Children.Add(lb_postdate);
                    //resultPart.Children.Add(lb_message);

                    //resultPart.Children.Add(lb_district);
                    //resultPart.Children.Add(lb_city);
                    //resultPart.Children.Add(lb_content);

                })
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Start,
                    Children = {
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Search Box Demo",
                            FontSize = 40
                        },
                        searchBar,
                        new ScrollView
                        {
                            Content = resultLabel,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        },
                        resultPart
                    },
                    Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5)
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
