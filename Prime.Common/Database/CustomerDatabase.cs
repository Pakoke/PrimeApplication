using Prime.Common.Dtos;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prime.Common.Database
{
    public partial class CustomerDatabase
    {
        protected SQLiteConnection _connection;

        public CustomerDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<UserDto>();
            _connection.CreateTable<ShopDto>();
            _connection.CreateTable<PrimeMaterialDto>();
            _connection.CreateTable<ProductDto>();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _connection.Table<ProductDto>().ToList();
        }

        public PrimeMaterialDto GetPrimesMaterial(string name)
        {
            return _connection.Table<PrimeMaterialDto>().FirstOrDefault(t => t.Name == name);
        }

        public void DeleteProduct(int id)
        {
            _connection.Delete<ProductDto>(id);
        }

        public void AddPrimeMaterial(string name)
        {
            var newMaterial = new PrimeMaterialDto()
            {
                Name = name
            };
            _connection.Insert(newMaterial);
        }

    }
}
