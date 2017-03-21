using Prime.Common.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamvvm;

namespace Prime.Common.Pages
{
    public partial class MainPage : ContentPage, IBasePage<MainPageModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
