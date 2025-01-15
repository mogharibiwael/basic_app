using System;
using CQRS_Lib.Data.Models;
using MediatR;

namespace CQRS_Lib.CQRS.Queries
{
	public record GetAllItemsQuery : IRequest<List<Product>>;

  
}

