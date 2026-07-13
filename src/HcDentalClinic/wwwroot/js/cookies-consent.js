window.getCookieConsent = () => {
    return localStorage.getItem("cookieConsent") || "";
};

window.setCookieConsent = () => {
    localStorage.setItem("cookieConsent", "true");
};