// note: when relying on visual studio to rebuild these assets,
// changes to this file may require a clean + build.

const colors = require("tailwindcss/colors");

module.exports = {
    darkMode: 'class',
    content: ["../*.razor", "../**/*.razor", "../**/**/*.razor", "../**/Themes/*.cs"],
    theme: {
        extend: {},
        colors: {
            // Now we build the full color palette, using all colors available
            // as shown at this link: https://tailwindcss.com/docs/customizing-colors#color-palette-reference
            transparent: "transparent",
            current: "currentColor",
            black: "#000",
            white: "#fff",
            gray: colors.gray,
            primary: colors.indigo,
            secondary: colors.gray,
            success: colors.emerald,
            error: colors.rose,
            info: colors.sky,
            warning: colors.amber,
        },
    },
    plugins: [],
}
