async function RegisterUser() {

    let uname = document.forms["formRegisterUser"]["uname"].value;
    let key = document.forms["formRegisterUser"]["key"].value;
    var isAdmin = document.getElementById('isAdminCheckBox').checked;

    console.log(`User entred input. (${uname} , ${key} and ${isAdmin})`);
    
    const options = {
        method: 'POST'
    };
    fetch(`https://localhost:5001/api/User/register?username=${uname}&password=${key}&isAdmin=${isAdmin}`, options);
}


