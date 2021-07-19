// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validateForm(sumbalance, maxbid) {
   
    let curentbid = Number (document.forms["myForm"]["Finalprice"].value);
    if  (curentbid > sumbalance) {
        alert("Недостатьо коштів");
        return false;
    } else if (curentbid <= maxbid)
    {
        alert("Cтавка замала");
        return false;

    }



}