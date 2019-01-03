// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code. 

// using zxcvbn library for password strength
var strength = {
    0: "Worst",
    1: "Bad",
    2: "Weak",
    3: "Good",
    4: "Strong"
}

var password = document.getElementById('password');
var strengthMeter = document.getElementById('password-strength');
var strengthText = document.getElementById('password-strength-text');


password.addEventListener('input', function () {
    var val = password.value;
    var result = zxcvbn(val);

    strengthMeter.value = result.score;

    if (val !== "") {
        strengthText.innerHTML = strength[result.score];
    } else {
        strengthText.innerHTML = "";
    }
});