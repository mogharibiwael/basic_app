using System;
using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.Data;
using CQRS_Lib.Data.Models;
using MediatR;

namespace CQRS_Lib.CQRS.Handelars
{
    public class GetItemsListHandelar : IRequestHandler<GetAllItemsQuery, List<Product>>
    {
        AppDbContext _db;

        public GetItemsListHandelar(AppDbContext db)
        {
            _db = db;

        }
        public async Task<List<Product>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {

            return await Task.FromResult(_db.Products.ToList());
        }
    }
}

