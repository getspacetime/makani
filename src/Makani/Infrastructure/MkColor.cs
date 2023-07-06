using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makani;

public class Test
{

    public void Foo()
    {
        var foo = MakaniColor.Slate;

        var zinc = MakaniColor.Zinc;
        var zincWithShade = MakaniColor.Zinc.One;
        var foo2 = MakaniColor.Zinc.Two;

        var two = MakaniColor.Slate;
        var three = MakaniColor.Slate;
        var one = MakaniColor.Slate.Zero;
        var shade1 = MakaniColor.Slate.One;
        var shade2 = MakaniColor.Slate.Three;
    }
}

public enum TextTransform
{
    Default,
    Uppercase,
    Lowercase,
    Capitalize
}

/// <summary>
/// Defines a base color with a shade.
/// </summary>
public class ColorWithShade
{
    public ColorWithShade(string baseColor, int shade = 5)
    {
        BaseColor = baseColor;
        Shade = shade;
    }

    /// <summary>
    /// The base color as a hex value.
    /// </summary>
    internal string BaseColor { get; set; }

    /// <summary>
    /// The shade of the color from 0 - 10, where 10 is the darkest.
    /// </summary>
    public int Shade { get; set; }

    public ColorWithShade Zero => new(BaseColor, 0);
    public ColorWithShade One => new(BaseColor, 1);
    public ColorWithShade Two => new(BaseColor, 2);
    public ColorWithShade Three => new(BaseColor, 3);
    public ColorWithShade Four => new(BaseColor, 4);
    public ColorWithShade Five => new(BaseColor, 5);
    public ColorWithShade Six => new(BaseColor, 6);
    public ColorWithShade Seven => new(BaseColor, 7);
    public ColorWithShade Eight => new(BaseColor, 8);
    public ColorWithShade Nine => new(BaseColor, 9);
    public ColorWithShade Ten => new(BaseColor, 10);
}

public class MakaniColor
{
    public static ColorWithShade Slate => new("slate");
    public static ColorWithShade Zinc => new("zinc");
    public static ColorWithShade Gray => new("gray");
    public static ColorWithShade Neutral => new("neutral");
    public static ColorWithShade Stone => new("stone");
    public static ColorWithShade Red => new("red");
    public static ColorWithShade Orange => new("orange");
    public static ColorWithShade Amber => new("amber");
    public static ColorWithShade Yellow => new("yellow");
    public static ColorWithShade Lime => new("lime");
    public static ColorWithShade Green => new("green");
    public static ColorWithShade Emerald => new("emerald");
    public static ColorWithShade Teal => new("teal");
    public static ColorWithShade Cyan => new("cyan");
    public static ColorWithShade Sky => new("sky");
    public static ColorWithShade Blue => new("blue");
    public static ColorWithShade Indigo => new("indigo");
    public static ColorWithShade Violet => new("violet");
    public static ColorWithShade Purple => new("purple");
    public static ColorWithShade Fuchsia => new("fuchsia");
    public static ColorWithShade Pink => new("pink");
    public static ColorWithShade Rose => new("rose");
}

// todo: experiment with our own colors with lightening/darkening  
//public class MakaniColor
//{
//    public static ColorWithShade Slate => new("#020617");
//    public static ColorWithShade Zinc => new("#09090b");
//    public static ColorWithShade Gray => new("#030712");
//    public static ColorWithShade Neutral => new("#0a0a0a");
//    public static ColorWithShade Stone => new("#0c0a09");
//    public static ColorWithShade Red => new("#450a0a");
//    public static ColorWithShade Orange => new("#431407");
//    public static ColorWithShade Amber => new("#451a03");
//    public static ColorWithShade Yellow => new("#422006");
//    public static ColorWithShade Lime => new("#1a2e05");
//    public static ColorWithShade Green => new("#052e16");
//    public static ColorWithShade Emerald => new("#022c22");
//    public static ColorWithShade Teal => new("#042f2e");
//    public static ColorWithShade Cyan => new("#083344");
//    public static ColorWithShade Sky => new("#082f49");
//    public static ColorWithShade Blue => new("#172554");
//    public static ColorWithShade Indigo => new("#1e1b4b");
//    public static ColorWithShade Violet => new("#2e1065");
//    public static ColorWithShade Purple => new("#3b0764");
//    public static ColorWithShade Fuchsia => new("#4a044e");
//    public static ColorWithShade Pink => new("#500724");
//    public static ColorWithShade Rose => new("#4c0519");
//}

public enum MkCardAlignment
{
    Top,
    Left
}