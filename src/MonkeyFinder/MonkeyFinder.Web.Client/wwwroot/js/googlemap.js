window.openMap = function (latitude, longitude) {
    const googleMapsUrl = `https://www.google.com/maps?q=${latitude},${longitude}&z=15`;

    window.open(googleMapsUrl, '_blank');
};