class Publisher
{
    public delegate void ProductEventHandler(string name);

    public event ProductEventHandler ProductAdded;

    public void AddProduct(string name)
    {
        System.Console.WriteLine("{0} is added", name);

        OnProductAdded(name);
    }

    protected virtual void OnProductAdded(string name)
    {
        ProductAdded(name);
    }
}