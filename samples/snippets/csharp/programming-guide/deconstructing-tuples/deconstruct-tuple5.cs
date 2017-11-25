using System;

public class Example
{
    // <Snippet1>
    public static void Main()
    {
        string city = "Raleigh";
        int population = 458880;
        double area = 144.8;

        (city, population, area) = QueryCityData("New York City");

        // Do something with the data.
    }
    // </Snippet1>

    private static (string, int, double) QueryCityData(string name)
    {
        if (name == "New York City")
            return (name, 8175133, 468.48);

        return ("", 0, 0);
    }
}
