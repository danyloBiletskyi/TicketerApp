﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmationDetailPage : ContentPage
	{
		public ConfirmationDetailPage (Confirmation selectedConfirmation)
		{
			InitializeComponent ();
			BindingContext = selectedConfirmation;
		}
	}
}