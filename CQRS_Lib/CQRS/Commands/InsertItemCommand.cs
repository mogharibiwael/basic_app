using System;
using CQRS_Lib.Data.Models;
using MediatR;

namespace CQRS_Lib.CQRS.Commands
{
	public record InsertItemCommand(Product Product) :IRequest<Product>;
	
}

