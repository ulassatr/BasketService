using System.Reflection;
using Autofac;
using BasketService.Application.Commands.AddItemToBasket;
using BasketService.Application.Configuration.Validation;
using BasketService.Application.Queries.GetBasket;
using FluentValidation;
using MediatR;

namespace BasketService.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetBasketQuery).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            
            builder.RegisterAssemblyTypes(typeof(GetBasketQueryHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequest<>));
            
            builder
                .RegisterAssemblyTypes(typeof(AddItemToBasketCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
            
            builder.RegisterGeneric(typeof(CommandValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => componentContext.TryResolve(t, out var o) ? o : null;
            });

        }
    }
}