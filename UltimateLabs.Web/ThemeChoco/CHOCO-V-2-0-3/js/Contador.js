function Suma() {
    var c = document.getElementById("qty");
    if (c.value==="1 1") {
        c.value = 11;
    }
    var num = parseInt(c.value) + 1;
    if (num === 11) {
        num = "1 1";
    }
    if (num > 12) {
        num = 1;
    }
    if (num < 1) {
        num = 12;
    }
    document.getElementById("qty").value = num;


};

function Resta() {
    var c = document.getElementById("qty");
    if (c.value === "1 1") {
        c.value = "11";
    }
    var num = parseInt(c.value) - 1;
    if (num === 11) {
        num = "1 1";
    }
    if (num > 12) {
        num = 1;
    }
    if (num < 1) {
        num = 12;
    }
    document.getElementById("qty").value = num;
    
};

function mostrar() {
    var Lista = document.getElementById("ListaPresentacion")
    var displayValue = document.getElementById('ListaPresentacion').style.display;

    if (displayValue === "" || displayValue==="none") {
        Lista.style.display = "block";
    }
    else {
        Lista.style.display = "none";
    }
};