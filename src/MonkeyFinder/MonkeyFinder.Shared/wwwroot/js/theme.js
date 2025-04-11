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