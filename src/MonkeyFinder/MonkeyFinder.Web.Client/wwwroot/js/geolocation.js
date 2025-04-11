window.getUserLocation = function () {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                resolve({
                    coords: {
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude,
                        altitude: position.coords.altitude
                    }
                });
            },
            (error) => {
                reject(error.message);
            }
        );
    });
};