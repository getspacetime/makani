export function highlight() {
    window.Prism.highlightAll();
}

export function blurActive() {
    document.activeElement.blur();
}

export function blur(element) {
    element.blur();
}