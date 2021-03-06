﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite11
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        public SelectPage()
        {
            InitializeComponent();

            //selectイベントハンドラ


            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {

                //this.ListView.ItemsSource = user.Name;//listview
                //Userテーブルの名前列をLabelに書き出す
                this.ListView.ItemsSource = user.Name;//listview
                layout.Children.Add(new Label { Text = user.Name });
            }



            Content = layout;
        }
    }
}
