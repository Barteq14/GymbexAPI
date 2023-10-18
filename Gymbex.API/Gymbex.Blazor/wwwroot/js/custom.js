window.general = {
    scrollToElement: function () {
        var element = document.querySelector('.register-login-container');
        if (element) {
            element.scrollIntoView({ behavior: 'smooth' });
        }
    }
}

function scrollToDiv() {
    var element = document.querySelector('.register-login-container');
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}

function scrollToTop() {
    window.scrollTo(0, 0);
}