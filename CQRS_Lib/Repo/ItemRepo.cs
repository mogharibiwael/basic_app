using System;
using CQRS_Lib.Data;
using CQRS_Lib.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Lib.Repo
{
	public class ItemRepo :	IitemRepo

        
	{
        private AppDbContext _db;

		public ItemRepo(AppDbContext db)
		{
            _db = db;
		}

       

        public Product GetProduct(int id)
        {
            var item = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public int InsertProduct(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges();

        }

        public int UpdateProduct(Product product)
        {
            try
            {
                _db.Products.Attach(product);
                _db.Entry(product).State = EntityState.Modified;
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public int DeleteProduct(int id)
        {
            var item = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (item != null) _db.Products.Remove(item);
            return _db.SaveChanges();
        }
    }
}

