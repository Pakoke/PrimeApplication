using Prime.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;

namespace Prime.Common.Models
{
    public class MainPageModel : BasePageModel
    {
        public MainPageModel()
        {
            ItemSelectedCommand = new BaseCommand<SelectedItemChangedEventArgs>((arg) =>
            {
                var item = arg?.SelectedItem as MenuItem;
                if (item != null)
                {
                    SelectedItem = null;
                    item.Command?.Execute(null);
                }
            });

            var menuItems = new List<MenuItem>() {

                new MenuItem() {
                    Section = "FlowListView",
                    Title = "Update items example",
                    Command = new BaseCommand(async (param) =>
                    {
                        var page = this.GetPageFromCache<ProductsGridPageModel>();
                        
                        await this.PushPageAsync(page, (model) => model.ReloadData());
                    }),
                }

            };

            var sorted = menuItems
                .OrderBy(item => item.Section)
                .GroupBy(item => item.Section)
                .Select(itemGroup => new Grouping<string, MenuItem>(itemGroup.Key, itemGroup));

            Items = new ObservableCollection<Grouping<string, MenuItem>>(sorted);
        }

        public ICommand ItemSelectedCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public object SelectedItem
        {
            get { return GetField<object>(); }
            set { SetField(value); }
        }

        public ObservableCollection<Grouping<string, MenuItem>> Items
        {
            get { return GetField<ObservableCollection<Grouping<string, MenuItem>>>(); }
            set { SetField(value); }
        }

        public class MenuItem : Xamvvm.BaseModel
        {
            string section;
            public string Section
            {
                get;set;
            }

            string title;
            public string Title
            {
                get; set;
            }

            string detail;
            public string Detail
            {
                get; set;
            }

            ICommand command;
            public ICommand Command
            {
                get; set;
            }

            object commandParameter;
            public object CommandParameter
            {
                get; set;
            }
        }
    }
}