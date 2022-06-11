module.exports = {
  content: ["../*.razor",  "../**/*.razor", "../**/**/*.razor"],
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
          warning: colors.amber
      },
  },
  plugins: [],
}
