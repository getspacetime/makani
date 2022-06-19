namespace Makani.Themes;

public class ButtonTheme
{
    public string Base { get; set; } =
        "inline-flex items-center border-0 focus:ring-2 rounded text-base my-2 md:mt-0 rounded outline-offset-2 outline-primary-500";

    public Dictionary<MkSize, string> Size { get; set; } = new()
        {
            {MkSize.Small, "py-1 px-2 text-sm mt-4"},
            {MkSize.Medium, "py-2 px-4 text-base mt-4 tracking-wide"},
            {MkSize.Large, "py-2 px-8 text-xl font-semibold mt-4 tracking-wide"},
            {MkSize.Default, "py-2 px-4 text-base mt-4 tracking-wide"}
        };

    public Dictionary<MkColor, string> Color { get; set; } = new()
    {
        {
            MkColor.Default,
            "bg-secondary-200 hover:bg-secondary-300 text-secondary-900 dark:bg-secondary-800 dark:hover:bg-secondary-700 dark:text-secondary-200 ring-white"
        },
        {
            MkColor.Secondary,
            "bg-secondary-200 hover:bg-secondary-300 text-secondary-900 dark:bg-secondary-800 dark:hover:bg-secondary-700 dark:text-secondary-200 ring-white"
        },
        {
            MkColor.Primary,
            "text-white bg-primary-500 border-0 ring-primary-200 hover:bg-primary-600 rounded"
        }
    };

    public Dictionary<MkVariant, string> Variant { get; set; }
}