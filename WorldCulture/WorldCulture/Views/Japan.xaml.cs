﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldCulture.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Japan : ContentPage
    {
        RadioButton[] radioButtons = new RadioButton[3];
        Label lbl, lbl1;
        Button btn;
        StackLayout stack;
        string[] s = new string[] { "The read Komodo Dragon", "The Sun", "The ongoing war between Japan and China" };
        public Japan()
        {
            stack = new StackLayout();

            lbl = new Label
            {
                Text = "What does the red circle on the Japanese flag mean?",
                Margin = new Thickness(20),
                FontAttributes = FontAttributes.Bold,
                FontSize = 25,
                TextColor = Color.Black,
            };
            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i] = new RadioButton() { Text = s[i] };
                stack.Children.Add(radioButtons[i]);
                radioButtons[i].CheckedChanged += Japan_CheckedChanged;
            }

            btn = new Button
            {
                Text = "Check answer",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 85,
            };

            lbl1 = new Label
            {
                Text = "Your answer: ",
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Center,
            };

            btn.Clicked += Btn_Clicked;

            StackLayout stackLayout = new StackLayout()
            {
                Children = { lbl, stack, lbl1, btn }
            };
            Content = stackLayout;
        }
        string qu;
        private void Japan_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            qu = (sender as RadioButton).Text;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (radioButtons[1].IsChecked)
            {
                lbl1.IsVisible = true;
                lbl1.TextColor = Color.Green;
                lbl1.Text = "Your answer: " + radioButtons[1].Text;

            }
            else
            {
                lbl1.IsVisible = true;
                lbl1.TextColor = Color.Red;
                lbl1.Text = "Your answer: " + qu;
            }
        }

        
    }
}