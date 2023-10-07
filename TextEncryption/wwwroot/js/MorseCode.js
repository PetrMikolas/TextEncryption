
// Validate keyboard input
function validateText() {

    let encrypt = document.getElementById('Encrypt');
    let decrypt = document.getElementById('Decrypt');

    if (encrypt.checked) {
        let charCode = (event.which) ? event.which : event.keyCode;
        if ((charCode == 32) || (charCode == 44) || (charCode == 46) || (charCode >= 48 && charCode <= 57) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) { return true; }
        else { return false; }
    }
    if (decrypt.checked) {
        let charCode = (event.which) ? event.which : event.keyCode;
        if ((charCode == 32) || (charCode == 45) || (charCode == 46) || (charCode == 124)) { return true; }
        else { return false; }
    }
}