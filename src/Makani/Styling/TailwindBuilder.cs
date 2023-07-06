namespace Makani.Styling;

internal class TailwindBuilder
{
    private readonly Dictionary<int, string> _map = new()
    {
        { 0, "50" },
        { 1, "100" },
        { 2, "200" },
        { 3, "300" },
        { 4, "400" },
        { 5, "500" },
        { 6, "600" },
        { 7, "700" },
        { 8, "800" },
        { 9, "900" },
        { 10, "950" },
    };

    private string css = string.Empty;
    private string Classes { get; set; } = string.Empty;
    private ColorWithShade? BackgroundColor { get; set; }
    private ColorWithShade? BorderColor { get; set; }
    private ColorWithShade? HoverBackgroundColor { get; set; }
    private double? Padding { get; set; }
    private double? VerticalPadding { get; set; }
    private double? HorizontalPadding { get; set; }
    private TextTransform TextTransform { get; set; }
    private MkSize FontSize { get; set; }
    private ColorWithShade? FontColor { get; set; }

    public static TailwindBuilder New()
    {
        return new TailwindBuilder();
    }

    public string Build()
    {
        if (BackgroundColor != null)
        {
            css = Append($"bg-{Translate(BackgroundColor)}");
        }

        if (HoverBackgroundColor != null)
        {
            css = Append($"hover:bg-{Translate(HoverBackgroundColor)}");
        }

        if (HoverBackgroundColor == null && BackgroundColor != null && BackgroundColor.Shade < 10)
        {
            // auto background color on hover
            var hover = new ColorWithShade(BackgroundColor.BaseColor, BackgroundColor.Shade + 1);
            css = Append($"hover:bg-{Translate(hover)}");
        }

        if (HoverBackgroundColor == null && BackgroundColor == null && BorderColor != null)
        {
            var hover = new ColorWithShade(BorderColor.BaseColor, 0);
            css = Append($"hover:bg-{Translate(hover)}");
        }

        if (Padding != null)
        {
            css = Append($"p-{Padding}");
        }

        if (VerticalPadding != null)
        {
            css = Append($"py-{VerticalPadding}");
        }

        if (HorizontalPadding != null)
        {
            css = Append($"px-{HorizontalPadding}");
        }

        if (TextTransform != TextTransform.Default)
        {
            css = Append(TransformText(TextTransform));
        }

        if (BorderColor != null)
        {
            css = Append($"border border-{Translate(BorderColor)}");
        }

        if (FontColor != null)
        {
            css = Append($"text-{Translate(FontColor)}");
        }

        if (!string.IsNullOrWhiteSpace(Classes))
        {
            css = Append(Classes);
        }

        css = Append(ToTextSize(FontSize));

        return css.Trim();
    }

    public TailwindBuilder AddBackground(ColorWithShade color)
    {
        BackgroundColor = color;

        return this;
    }

    public TailwindBuilder AddBackgroundHover(ColorWithShade color)
    {
        HoverBackgroundColor = color;

        return this;
    }

    public TailwindBuilder AddBorder(ColorWithShade color)
    {
        BorderColor = color;

        return this;
    }

    public TailwindBuilder AddPadding(double padding)
    {
        Padding = padding;

        return this;
    }

    public TailwindBuilder AddPadding(double x, double y)
    {
        VerticalPadding = y;
        HorizontalPadding = x;
        return this;
    }

    public TailwindBuilder AddVerticalPadding(double padding)
    {
        VerticalPadding = padding;

        return this;
    }

    public TailwindBuilder AddHorizontalPadding(double padding)
    {
        HorizontalPadding = padding;

        return this;
    }

    public TailwindBuilder AddClasses(string classes)
    {
        Classes = $"{Classes} {classes}";

        return this;
    }

    public TailwindBuilder AddTextTransform(TextTransform t)
    {
        TextTransform = t;

        return this;
    }

    public TailwindBuilder SetFontSize(MkSize s)
    {
        FontSize = s;

        return this;
    }

    public TailwindBuilder SetFontColor(ColorWithShade color)
    {
        FontColor = color;
        return this;
    }

    private string Append(string s)
    {
        css = $"{css} {s}";
        return css;
    }

    private string Translate(ColorWithShade color)
    {
        return $"{color.BaseColor}-{_map[color.Shade]}";
    }

    private string TransformText(TextTransform t)
    {
        return t switch
        {
            TextTransform.Uppercase => "uppercase",
            TextTransform.Lowercase => "lowercase",
            TextTransform.Capitalize => "capitalize",
            _ => string.Empty,
        };
    }

    private string ToTextSize(MkSize s)
    {
        return s switch
        {
            MkSize.ExtraSmall => "text-xs",
            MkSize.Small => "text-sm",
            MkSize.Medium => "text-base",
            MkSize.Large => "text-lg",
            MkSize.ExtraLarge => "text-xl",
            _ => "text-base"
        };
    }
}