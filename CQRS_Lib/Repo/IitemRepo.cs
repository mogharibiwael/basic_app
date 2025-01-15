using System;
using CQRS_Lib.Data.Models;

namespace CQRS_Lib.Repo
{
	public interface IitemRepo
	{
		public List<Product> GetProducts();
		public Product GetProduct(int id);
		public int InsertProduct(Product product);
		public int UpdateProduct(Product product);
		public int DeleteProduct(int id);
	}
}

