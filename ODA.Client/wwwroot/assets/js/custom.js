//paste this code under the head tag or in a separate js file.
// Wait for window load
setStorage = function (key, value) {
    localStorage.setItem(key, value);
}

getStorage = function (key) {
    return localStorage.getItem(key);
}

removeStorage = function (key) {
    localStorage.removeItem(key);
}
$(window).load(function () {
    // Animate loader off screen
    $(".page-loader").fadeOut("slow");;
});
