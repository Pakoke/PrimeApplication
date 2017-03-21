using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamvvm;
using Xamarin.Forms;
using System.Linq;
using Prime.Common.Pages;
using Plugin.Toasts;

namespace Prime.Common.Models
{
    public class ProductsGridPageModel : BasePageModel
    {
        static int insertId = 0;
        IToastNotificator notificator = DependencyService.Get<IToastNotificator>();

        public ProductsGridPageModel()
        {
            ItemTappedCommand = new BaseCommand((param) =>
            {

                var item = LastTappedItem as ComplexItem;
                if (item != null)
                {
                    //Is the button add
                    if (item.IsDirty)
                    {
                        AddCommand = new BaseCommand((arg) =>
                        {
                            insertId++;
                            Items.Insert(Items.Count - 1, new ComplexItem() { Title = string.Format("New {0}", insertId) });
                        });
                        AddCommand.Execute(param);
                    }
                    else
                    {
                        var options = new NotificationOptions()
                        {
                            Title = "Title",
                            Description = "Description"
                        };

                        notificator.Notify(new NotificationOptions()
                        {
                            Title = item.Title,
                            Description = item.CreatedAt.ToString()
                        });
                        System.Diagnostics.Debug.WriteLine("Tapped {0}", item.Title);
                    }
                    
                }
            });

            

            RemoveCommand = new BaseCommand((arg) =>
            {
                Items.RemoveAt(Items.Count - 1);
            });
        }

        public ObservableCollection<object> Items
        {
            get { return GetField<ObservableCollection<object>>(); }
            set { SetField(value); }
        }

        public void ReloadData()
        {
            var exampleData = new ObservableCollection<object>();

            exampleData.Add(new ComplexItem()
            {
                Color = Color.Aqua,
                Id = Guid.NewGuid(),
                Title = "Manzanas",
                CreatedAt = DateTime.Now,
                IsDirty = false,
                ImageUrl = "https://farm9.staticflickr.com/8351/8299022203_de0cb894b0.jpg"
            });

            exampleData.Add(new ComplexItem()
            {
                Color = Color.Black,
                Id = Guid.NewGuid(),
                Title = "Peras",
                CreatedAt = DateTime.Now,
                IsDirty = false,
                ImageUrl= "https://farm8.staticflickr.com/7524/15620725287_3357e9db03.jpg"
            });

            exampleData.Add(new ComplexItem()
            {
                Color = Color.Blue,
                Id = Guid.NewGuid(),
                Title = "Naranjas",
                CreatedAt = DateTime.Now,
                IsDirty = false,
                ImageUrl= "https://farm1.staticflickr.com/44/117598011_250aa8ffb1.jpg"
            });

            exampleData.Add(new ComplexItem()
            {
                Color = Color.Olive,
                Id = Guid.NewGuid(),
                Title = "Platanos",
                CreatedAt = DateTime.Now,
                IsDirty = false,
                ImageUrl= "https://farm3.staticflickr.com/2475/4058009019_ecf305f546.jpg"
            });

            exampleData.Add(new ComplexItem()
            {
                Title = "Add",
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                IsDirty = true,
                ImageUrl= "image_add.png"
            });

            Items = exampleData;
        }

        public ICommand ItemTappedCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand AddCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand RemoveCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public object LastTappedItem
        {
            get { return GetField<object>(); }
            set { SetField(value); }
        }

        public class ComplexItem : BaseModel
        {
            public string Title { get; set; }

            public Color Color { get; set; } = Color.Blue;

            public string ImageUrl { get; set; }

        }

        
    }
}
