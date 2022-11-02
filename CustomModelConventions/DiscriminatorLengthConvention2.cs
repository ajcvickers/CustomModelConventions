public class DiscriminatorLengthConvention2 : IModelFinalizingConvention
{
    private readonly int _discriminatorLength;

    public DiscriminatorLengthConvention2(int discriminatorLength)
    {
        _discriminatorLength = discriminatorLength;
    }

    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var entityType in modelBuilder.Metadata.GetEntityTypes()
                     .Where(entityType => entityType.BaseType == null))
        {
            var discriminatorProperty = entityType.FindDiscriminatorProperty();
            if (discriminatorProperty != null
                && discriminatorProperty.ClrType == typeof(string))
            {
                discriminatorProperty.Builder.HasMaxLength(_discriminatorLength);
            }
        }
    }
}
