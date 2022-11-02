public class DiscriminatorLengthConvention1 : IEntityTypeBaseTypeChangedConvention
{
    private readonly int _discriminatorLength;

    public DiscriminatorLengthConvention1(int discriminatorLength)
    {
        _discriminatorLength = discriminatorLength;
    }

    public void ProcessEntityTypeBaseTypeChanged(
        IConventionEntityTypeBuilder entityTypeBuilder,
        IConventionEntityType? newBaseType,
        IConventionEntityType? oldBaseType,
        IConventionContext<IConventionEntityType> context)
    {
        var discriminatorProperty = entityTypeBuilder.Metadata.FindDiscriminatorProperty();
        if (discriminatorProperty != null
            && discriminatorProperty.ClrType == typeof(string))
        {
            discriminatorProperty.Builder.HasMaxLength(_discriminatorLength);
        }
    }
}
