public class Warehouse
{
    private List<Product> _products = new List<Product>();

    public string Name { get; private set; }

    public int ProductCount
    {
        get { return _products.Count; }
    }

    public Warehouse(string name)
    {
        Name = name;
    }

    public bool AddProduct(Product product)
    {
        if (FindProductByName(product.Name) != null)
        {
            return false;
        }

        _products.Add(product);
        return true;
    }

    public Product? FindProductByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        string searchName = name.Trim();

        foreach (Product item in _products)
        {
            if (string.Equals(item.Name.Trim(), searchName, StringComparison.OrdinalIgnoreCase))
            {
                return item;
            }
        }

        return null;
    }

    public bool RemoveProduct(string name)
    {
        Product? product = FindProductByName(name);
        if (product == null)
        {
            return false;
        }

        return _products.Remove(product);
    }

    public List<Product> GetProducts()
    {
        List<Product> result = new List<Product>();
        foreach (Product item in _products)
        {
            result.Add(item);
        }
        return result;
    }

    public int CountLowStock(int threshold)
    {
        int count = 0;
        foreach (Product item in _products)
        {
            if (item.StockQuantity < threshold)
            {
                count += 1;
            }
        }
        return count;
    }
}
