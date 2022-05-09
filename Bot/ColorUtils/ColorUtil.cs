using System.Globalization;
using Discord;

namespace ConsoleApp1.ColorUtils;

public class ColorUtil
{
    public static Color setColor(int r, int g, int b)
    {
        var color = new Color(r, g, b);
        return color;
    }
    
    public static Color setColor(string hex)
    {
        if (hex.StartsWith("#"))
            hex = hex.Substring(1);
        
        Console.WriteLine(hex);

        if (hex.Length != 6) throw new Exception("Color is not valid!");
        
        Console.WriteLine(hex);

        int r = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
        int g = int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
        int b = int.Parse(hex.Substring(4, 2),NumberStyles.HexNumber);
        
        return setColor(r, g, b);
    }
}