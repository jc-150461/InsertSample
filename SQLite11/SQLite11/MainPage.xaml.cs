using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206

namespace SQLite11
{
    public partial class MainPage : ContentPage
    {
        //http://www.atmarkit.co.jp/ait/articles/1612/28/news021.html　ScrollView

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //Userテーブルに適当なデータを追加
            /*
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");
            //↑この辺をボタンに突っ込む
            */
            //Userテーブルの行データを取得

            var query = UserModel.selectUser();

            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出します
                layout.Children.Add(new Label { Text = user.Name });
            }

            Content = layout;




            /******************************************追加********************************************************/
            var ar = new ObservableCollection<UserModel>();

            var listView = new ListView
            {
                //ItemsSource = UserModel.selectUser(),
                //ItemTemplate = new DataTemplate(typeof(TextCell))
                ItemsSource = ar,
                ItemTemplate = new DataTemplate(() => new Cell(this)),
            };

            if (UserModel.selectUser() != null)
            {
                ar = new ObservableCollection<UserModel>(UserModel.selectUser());
            }


    class Cell : ViewCell
        {
            public Cell(MainPage myPage)
            {
                var label = new Label
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                //label.SetBinding(Label.TextProperty, new Binding("."));

                var actionDelete = new MenuItem
                {
                    Text = "Delete",
                    Command = new Command(p => myPage.DisplayAlert("Delete", p.ToString(), "OK")),
                    IsDestructive = true,
                };
                /*
            actionDelete.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            actionDelete.Clicked += (s, a) => myPage.((MenuItem)s);
            ContextActions.Add(actionDelete);


            View = new StackLayout
            {
                Padding = 10,
                Children = { label }
            };
        }
    }

    /******************************************ここまで追加********************************************************/



                /**********************************************************

                private Entry insertEntry; //insertの入力フィールド
                private Entry deleteEntry; //deleteの入力フィールド
                private int deleteId; //削除Idフィールド

                private string sb; //スクロールビューで使うかも

                public MainPage()
                {
                    InitializeComponent();

                    var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

                    //-------------------------------insertします-------------------------------
                    var Insert = new Button
                    {
                        WidthRequest = 60,
                        Text = "Insert!",
                        TextColor = Color.Red,
                    };
                    insertEntry = new Entry
                    {
                        WidthRequest = 60
                    };
                    layout.Children.Add(Insert);
                    Insert.Clicked += InsertClicked;
                    layout.Children.Add(insertEntry);

                    //--------------------------------deleteします------------------------------
                    var Delete = new Button
                    {
                        WidthRequest = 60,
                        Text = "Delete!",
                        TextColor = Color.Red,
                    };
                    layout.Children.Add(Delete);
                    Delete.Clicked += DeleteClicked;
                    /*
                    deleteEntry = new Entry
                    {
                        WidthRequest = 60,
                    };
                    layout.Children.Add(deleteEntry);
                    deleteId = int.Parse(deleteEntry.Text);


                    //--------------------------------selectします------------------------------
                    var Select = new Button
                    {
                        WidthRequest = 60,
                        Text = "Select!",
                        TextColor = Color.Red,
                    };
                    layout.Children.Add(Select);
                    Select.Clicked += SelectClicked;
                    /*******************************************************
                    /****
                    if(UserModel.selectUser() == null)
                    {
                        UserModel.insertUser("筋トレ01");
                        UserModel.insertUser("筋トレ02");
                        UserModel.insertUser("筋トレ03");

                    }
                    /****




                    Content = layout;

                }
                /*************************************


                //insertイベントハンドラ
                void InsertClicked(object sender, EventArgs e)
                {

                    var InsertName = insertEntry.Text;
                    //Userテーブルに適当なデータを追加する
                    UserModel.insertUser(InsertName);

                }

                //deleteイベントハンドラ
                void DeleteClicked(object sender, EventArgs e)
                {
                    //UserModel.deleteUser(deleteId);
                    UserModel.deleteUser(1);

                }

                //selectイベントハンドラ
                void SelectClicked(object sender, EventArgs e)
                {

                    //Userテーブルの行データを取得
                    var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
                    var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };


                    foreach (var user in query)
                    {
                        //Userテーブルの名前列をLabelに書き出す
                        //this.ListView.ItemsSource = user.Name;//listview
                       // layout.Children.Add(new Label { Text = user.Name });
                    }
                    //selectする
                    var Select = new Button
                    {
                        WidthRequest = 60,
                        Text = "Select!",
                        TextColor = Color.Red,

                    };
                    layout.Children.Add(Select);
                    Select.Clicked += SelectClicked;




                    //insertする
                    var Insert = new Button
                    {
                        WidthRequest = 60,
                        Text = "Insert!",
                        TextColor = Color.Red,
                    };
                    insertEntry = new Entry
                    {
                        WidthRequest = 60
                    };
                    layout.Children.Add(Insert);
                    Insert.Clicked += InsertClicked;
                    layout.Children.Add(insertEntry);

                    Content = layout;

                    Navigation.PushAsync(new SelectPage());

                    /********************


                    /*
                        var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
                        foreach (var user in query)
                        {
                            var sb = new Label { Text = user.Name };
                        }
                        var scrollView = new ScrollView
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            //ラベルを配置する
                            Content = new Label
                            {
                                Text = sb.ToString(),
                                FontSize = 20,
                                TextColor = Color.Red,
                            }
                        };
                        Content = scrollView;*/
            }
        }
    }
}

