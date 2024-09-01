
public sealed class Singletone
{
    public static Singletone instance = null;

    private static readonly object locker = new object();

    private Singletone()
    {

    }

    public static Singletone Instance
    {
        get
        {
            lock(locker)
            {
                if(instance == null)
                {
                    instance = new Singletone();
                }
                return instance;
            }
        }
    }

}