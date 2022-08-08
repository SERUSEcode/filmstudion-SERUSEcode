async function RegisterUser() {

    let name = document.forms["RegisterFilmstuidoForm"]["uname"].value;
    let city = document.forms["RegisterFilmstuidoForm"]["city"].value;
    let key = document.forms["RegisterFilmstuidoForm"]["key"].value;

    console.log(`User entred input. (${name} and ${city})`);
    
    const options = {
        method: 'POST'
    };
    fetch(`https://localhost:5001/api/Filmstudio/register?name=${name}&city=${city}&password=${key}`, options);
}
