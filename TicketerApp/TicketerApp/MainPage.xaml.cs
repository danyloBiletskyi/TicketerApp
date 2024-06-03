﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.ModelRenderers;
using TicketerApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TicketerApp
{
    public partial class MainPage
    {
        private Button brightThemeButton;
        private Button darkThemeButton;
        private SuccessfulLoginRegistrationResponseModel _model;
        public MainPage(SuccessfulLoginRegistrationResponseModel model)
        {
            InitializeComponent();
            ObservableCollection<Confirmation> requestsToConfirm = new ObservableCollection<Confirmation>();
            // some code to get all requests
            _model = model;
            ThemeButtonsInitialization();
            StackLayoutRendererInitialization();
        }

        void ThemeChange(object sender, EventArgs e)
        {
            if (sender == brightThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
            else if (sender == darkThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Unspecified;
            }
        }

        void ThemeButtonsInitialization()
        {
            brightThemeButton = FindByName("bright") as Button;
            darkThemeButton = FindByName("dark") as Button;
            brightThemeButton.Clicked += ThemeChange;
            darkThemeButton.Clicked += ThemeChange;
        }

        void StackLayoutRendererInitialization()
        {
            Style boxViewBottomBorderStyle = (Style)this.Resources["BoxViewBottomBorder"];

            StackLayout confirmationStackLayout = FindByName("ConfirmationGridList") as StackLayout;
            ConfirmationRenderer confirmationRenderer = new ConfirmationRenderer(confirmationStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style confirmationStyle = (Style)this.Resources["CollectionViewBackGroundStyle"];
            Style boxViewConfirmationStyle = (Style)this.Resources["TicketBoxViewStyle"];
            confirmationRenderer.Render(confirmationStyle, (boxViewBottomBorderStyle, boxViewConfirmationStyle));


            StackLayout ticketsStackLayout = FindByName("TicketsGridList") as StackLayout;
            TicketRenderer ticketRenderer = new TicketRenderer(ticketsStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style ticketsStyle = (Style)this.Resources["CollectionViewBackGroundStyle"];
            Style boxViewTicketsStyle = (Style)this.Resources["TicketBoxViewStyle"];
            
            ticketRenderer.Render(ticketsStyle, (boxViewBottomBorderStyle, boxViewTicketsStyle));
        }

        private void logOutClickedEventHandler(object sender, EventArgs e)
        {
            Preferences.Set("logged_in", false);
            Preferences.Remove("token");
            Preferences.Remove("expires_at");
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
