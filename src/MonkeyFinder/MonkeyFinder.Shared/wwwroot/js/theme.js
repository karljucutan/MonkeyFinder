window.setTheme = function (mode) {
    const darkModeLink = document.getElementById('dark-mode');
    const lightModeLink = document.getElementById('light-mode');

    if (mode === 'dark') {
        darkModeLink.disabled = false;
        lightModeLink.disabled = true;
    } else {
        darkModeLink.disabled = true;
        lightModeLink.disabled = false;
    }
};

window.getSystemTheme = function () {
    if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
        return 'dark';
    } else {
        return 'light';
    }
};
