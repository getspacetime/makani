export function highlight() {
    window.Prism.highlightAll();
}

export function blurActive() {
    document.activeElement.blur();
}

export function blur(element) {
    element.blur();
}

export function isDarkMode() {
    return localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)
}

export function scrollToFragment(elementId) {
    if (!elementId) {
        return;
    }
    
    const element = document.getElementById(elementId);

    if (element) {
        element.scrollIntoView({
            behavior: 'smooth'
        });
    }
}

/**
 * Adds support for dark mode and reads the OS preference.
 *
 * If a user has selected dark mode manually, reads this value first.
 */
export function addDarkModeSupport() {
    // On page load or when changing themes, best to add inline in `head` to avoid FOUC
    if (isDarkMode()) {
        addDarkCss();
    } else {
        removeDarkCss();
    }
}

/*
 * User specifically requests dark mode
 */
export function changeDarkMode(on) {
    if (on) {
        localStorage.theme = 'dark';
        addDarkCss();
    } else {
        localStorage.theme = 'light';
        removeDarkCss();
    }
}

/**
 * Resets local preferences in favor of OS preference (prefers-color-scheme)
 */
export function useOSPreference() {
    localStorage.removeItem('theme');
}

function addDarkCss() {
    document.documentElement.classList.add('dark');
}

function removeDarkCss() {
    document.documentElement.classList.remove('dark');
}