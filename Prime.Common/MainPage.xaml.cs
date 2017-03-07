using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamvvm;

namespace Prime.Common
{
    public partial class MainPage : ContentPage, IBasePage<MainPageModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
