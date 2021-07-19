// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validateForm(sumbalance, maxbid) {
   
    let curentbid = Number (document.forms["myForm"]["Finalprice"].value);
    if (curentbid < maxbid || curentbid > sumbalance) {
        alert("Name must be filled out");
        return false;
    }
}