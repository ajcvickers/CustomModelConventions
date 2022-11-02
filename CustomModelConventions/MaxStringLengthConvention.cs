public class MaxStringLengthConvention : IModelFinalizingConvention
{
    private readonly int _maxLength;

    public MaxStringLengthConvention(int maxLength)
    {
        _maxLength = maxLength;
    }

    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var property in modelBuilder.Metadata.GetEntityTypes()
                     .SelectMany(
                         e => e.GetDeclaredProperties()
                             .Where(p => p.ClrType == typeof(string))))
        {
            property.Builder.HasMaxLength(_maxLength);
        }
    }
}
