app.service('sessionVariables', function () {

    this.current = {

        //clientShortCode
        get clientShortCode() {
            if (sessionStorage.getItem('clientShortCode') === null)
            {
                sessionStorage.setItem('clientShortCode', "");
            }
            return sessionStorage.getItem('clientShortCode');
        },
        set clientShortCode(val) {
            sessionStorage.setItem('clientShortCode',val);
        },

        //clientId
        get clientId() {
            if (sessionStorage.getItem('clientId') === null)
            {
                sessionStorage.setItem('clientId', "");
            }
            return sessionStorage.getItem('clientId');
        },
        set clientId(val) {
            sessionStorage.setItem('clientId', val);
        },

        //clientName
        get clientName() {
            if (sessionStorage.getItem('clientName') === null) {
                sessionStorage.setItem('clientName', "");
                //sessionStorage.setItem('clientName', "test");
            }
            return sessionStorage.getItem('clientName');
        },
        set clientName(val) {
            sessionStorage.setItem('clientName', val);
        }

    }
});