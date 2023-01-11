using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;

namespace iRenta.TestTask.Application.Products.Queries;

public record GetProductByCodeQuery(sbyte Code) : IQuery<Maybe<ProductResponse>>;
