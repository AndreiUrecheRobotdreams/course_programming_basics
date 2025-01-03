Namespace Program.cs
using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json; 

// Třída Product
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// Vlastní výjimka pro neplatné produkty
public class InvalidProductException : Exception
{
    public InvalidProductException(string message) : base(message) { }
}

// Třída Catalog
public class Catalog
{
    public List<Product> Products { get; set; }

    public Catalog()
    {
        Products = new List<Product>();
    }

    // Metoda pro přidání produktu
    public void AddProduct(Product product)
    {
        if (product.Price < 0)
        {
            throw new InvalidProductException("Cena produktu nemůže být negativní.");
        }
        Products.Add(product);
    }

    // Metoda pro serializaci do JSON
    public List<string> SerializeProducts()
    {
        return Products.Select(p => JsonConvert.SerializeObject(p)).ToList();
    }

    // Metoda pro deserializaci z JSON
    public void DeserializeProducts(List<string> productJsons)
    {
        try
        {
            foreach (var json in productJsons)
            {
                var product = JsonConvert.DeserializeObject<Product>(json);
                if (product.Price < 0)
                {
                    throw new InvalidProductException("Cena produktu nemůže být negativní.");
                }
                AddProduct(product);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Chyba při deserializaci JSON: " + ex.Message);
        }
        catch (InvalidProductException ex)
        {
            Console.WriteLine("Chyba při přidávání produktu: " + ex.Message);
        }
    }
}

// Program pro testování
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Vytvoření instance katalogu
            var catalog = new Catalog();

            // Přidání produktů do katalogu
            catalog.AddProduct(new Product("Laptop", 1200.00m, 10));
            catalog.AddProduct(new Product("Smartphone", 800.00m, 25));

            // Serializace produktů
            var serializedProducts = catalog.SerializeProducts();
            foreach (var serialized in serializedProducts)
            {
                Console.WriteLine(serialized);
            }

            // Vytvoření validního JSON stringu pro nový produkt
            string jsonProduct = "{\"Name\":\"Tablet\",\"Price\":500.00,\"Quantity\":15}";

            // Deserializace a přidání produktu
            List<string> newJsonList = new List<string> { jsonProduct };
            catalog.DeserializeProducts(newJsonList);

            // Zobrazit produkty po deserializaci
            Console.WriteLine("Produkty po deserializaci:");
            foreach (var product in catalog.Products)
            {
                Console.WriteLine($"Název: {product.Name}, Cena: {product.Price}, Množství: {product.Quantity}");
            }
        }
        catch (InvalidProductException ex)
        {
            Console.WriteLine("Chyba při vytváření produktu: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Neočekávaná chyba: " + ex.Message);
        }
    }
}
