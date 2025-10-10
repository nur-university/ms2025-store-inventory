using Joseco.DDD.Core.Results;
using MediatR;

namespace Inventory.Application.Items.GetItems;

public record GetItemsQuery() : IRequest<Result<ICollection<ItemDto>>>;