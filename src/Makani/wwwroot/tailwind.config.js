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
            primary: colors.sky,
            secondary: colors.gray,
            success: colors.emerald,
            error: colors.rose,
            info: colors.sky,
            warning: colors.amber,
            slate: colors.slate,
            neutral: colors.slate,
            stone: colors.stone,
            orange: colors.orange,
            amber: colors.amber,
            yellow: colors.yellow,
            lime: colors.lime,
            green: colors.green,
            emerald: colors.emerald,
            teal: colors.teal,
            cyan: colors.cyan,
            sky: colors.sky,
            blue: colors.blue,
            indigo: colors.indigo,
            violet: colors.violet,
            purple: colors.purple,
            fuchsia: colors.fuchsia,
            pink: colors.pink,
            rose: colors.rose,
        },
    },
    plugins: [],
}
