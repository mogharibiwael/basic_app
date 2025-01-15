using System;
using CQRS_Lib.CQRS.Commands;
using CQRS_Lib.Data;
using CQRS_Lib.Data.Models;
using MediatR;

namespace CQRS_Lib.CQRS.Handelars
{
    public class InsertItemHandler : IRequestHandler<InsertItemCommand, Product>
    {

        private AppDbContext _db;

        public InsertItemHandler(AppDbContext db)
        {
            _db = db;

        }
        public async Task<Product> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
           await _db.Products.AddAsync(request.Product);
            _db.SaveChanges();
            return await Task.FromResult(request.Product);
        }
    }
}

