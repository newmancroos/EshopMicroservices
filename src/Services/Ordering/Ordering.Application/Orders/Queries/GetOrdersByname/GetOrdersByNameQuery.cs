﻿namespace Ordering.Application.Orders.Queries.GetOrdersByname;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrderByNameResult>;

public record GetOrderByNameResult(IEnumerable<OrderDto> Orders);

