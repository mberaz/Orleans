using Orleans.Runtime;

namespace Orleans
{
    public sealed class StartupTask(IGrainFactory grainFactory) : IStartupTask
    {
        async Task IStartupTask.Execute(CancellationToken cancellationToken)
        {
            //do somethings
            //var faker = new ProductDetails().GetBogusFaker();

            //foreach (var product in faker.GenerateLazy(50))
            //{
            //    var productGrain = grainFactory.GetGrain<IProductGrain>(product.Id);
            //    await productGrain.CreateOrUpdateProductAsync(product);
            //}
        }
    }
}
