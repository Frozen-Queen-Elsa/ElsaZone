namespace ElsaZone.Utilities.Exceptions;

public class ElsazoneException:Exception
{
    public ElsazoneException()
    {
        
    }

    public ElsazoneException(string message): base(message)
    {
        
    }
    public ElsazoneException(string message,Exception inner):base(message,inner)
    {
        
    }
}