window.getNetworkInformation = function () {
    if (navigator.connection) {
        return {
            isSupported: true,
            type: navigator.connection.type || "unknown",
            effectiveType: navigator.connection.effectiveType || "unknown",
            rtt: navigator.connection.rtt || 0,
            saveData: navigator.connection.saveData || false
        };
    } else {
        return {
            isSupported: false,
            type: "unknown",
            effectiveType: "unknown",
            rtt: 0,
            saveData: false
        };
    }
};
