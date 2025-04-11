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
// For export/import.
//      use export function getNetworkInformation()
// Call the module like this, or add a field and lazyload.
//      var module = await JS.InvokeAsync<IJSObjectReference>("import", "/js/interops.js");
// Invoke the method
//      var networkInfo = await module.InvokeAsync < NetworkInfo > ("getNetworkInformation");