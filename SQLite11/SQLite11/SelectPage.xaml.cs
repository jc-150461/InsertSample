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
		public SelectPage ()
		{
			InitializeComponent ();

            var select1 = new UserModel();
		}
	}
}