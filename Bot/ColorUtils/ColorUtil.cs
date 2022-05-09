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

        if (hex.Length != 6) throw new Exception("Color not valid");

        int r = Int32.Parse(hex.Substring(0, 2));
        int g = Int32.Parse(hex.Substring(2, 2));
        int b = Int32.Parse(hex.Substring(4, 2));
        
        return setColor(r, g, b);
    }
}