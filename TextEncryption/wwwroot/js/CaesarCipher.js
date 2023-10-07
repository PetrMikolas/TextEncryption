
// Validate keyboard input
function validateText() {

    let encrypt = document.getElementById('Encrypt');
    let decrypt = document.getElementById('Decrypt');

    if (encrypt.checked || decrypt.checked) {
        let charCode = (event.which) ? event.which : event.keyCode;
        if ((charCode == 32) || (charCode == 44) || (charCode == 46) || (charCode >= 97 && charCode <= 122)) { return true; }
        else { return false; }
    }
}  

function validateNumber() {

    let shift = document.getElementById('Shift');   

    if (shift.onkeypress) {
        let charCode = (event.which) ? event.which : event.keyCode;
        if ((charCode >= 48 && charCode <= 57)) { return true; }
        else { return false; }
    }
}