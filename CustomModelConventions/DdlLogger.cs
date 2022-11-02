public static class DdlLogger
{
    public static void Log(string message)
    {
        var trimmedMessage = string.Join(Environment.NewLine, message.Split(Environment.NewLine).Skip(2));
        if (trimmedMessage.StartsWith("      CREATE ", StringComparison.Ordinal))
        {
            Console.WriteLine(trimmedMessage);
            Console.WriteLine();
        }
    }
}
