// EmailJS interop.js
globalThis.EmailJSInterop = {
    init: function(publicKey) {
        emailjs.init({
            publicKey: publicKey,
            blockHeadless: true,
        });
    },
    send: async function (serviceId, templateId, templateParams) {
        try {
            const response = await emailjs.send(serviceId, templateId, templateParams);
            return { success: true, status: response.status, text: response.text };
        } catch (error) {
            return { success: false, status: error.status || 0, text: error.text || error.message || 'An error occurred' };
        }
    }
};