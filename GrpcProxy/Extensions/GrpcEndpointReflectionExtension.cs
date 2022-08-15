namespace GrpcProxy.Extensions;

public static class GrpcEndpointReflectionExtension
{
    [Obsolete("Should be refactored, remade to return GrpcServiceEndpointConventionBuilder")]
    public static void MapGrpcService(this IEndpointRouteBuilder builder, Type serviceType)
    {
        var grpcEndpointsBuilderType = typeof(GrpcEndpointRouteBuilderExtensions);
        var mapGrpcMethod =  grpcEndpointsBuilderType.GetMethod("MapGrpcService");
        var grpcMapperConstructed = mapGrpcMethod.MakeGenericMethod(serviceType);
        grpcMapperConstructed.Invoke(null, new[] { builder });
        
        
        //todo this method not void. it should be like in original class
        // var serviceRouteBuilder = builder.ServiceProvider.GetRequiredService<ServiceRouteBuilder<TService>>();
        // var endpointConventionBuilders = serviceRouteBuilder.Build(builder);
        // return new GrpcServiceEndpointConventionBuilder(endpointConventionBuilders);
    }

}