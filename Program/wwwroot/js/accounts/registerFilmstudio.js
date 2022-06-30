async function RegisterUser() {

    let name = document.forms["formRegisterUser"]["uname"].value;

    console.log(`User entred input. (${name})`);
    
    const options = {
        method: 'POST'
    };
    fetch(`//localhost:5001/api/Filmstudio/register?name=${name}`, options);
}

