console.log("Uzkrauta:", "BilietuKaina.js");
document.getElementById('Ticket_SedimaVieta_ID').onchange = function () {
    var kaina = document.getElementById('Ticket_Kaina');
    kaina.value = parseInt((1 + parseFloat(8 - this.options[this.selectedIndex].value) / 15) * 300);
};
(function () {
    var i = 0;
    var elements = document.querySelector('.do-readonly').querySelectorAll('input');
    for (i = 0; i < elements.length; i++) {
        elements[i].setAttribute("readOnly", true);
    }
    var elementsSel = document.querySelector('.do-readonly').querySelectorAll('select');
    for (i = 0; i < elementsSel.length; i++) {
        elementsSel[i].setAttribute("disabled", true);
    }
    //var sedimaVieta = document.getElementById('Ticket_SedimaVieta_ID');
    //var sedimaVietaList = document.getElementById('Ticket_SedimaVieta_ID');
})();