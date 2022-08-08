async function Login() {

    let uname = document.forms["form"]["uname"].value;
    let key = document.forms["form"]["key"].value;

    console.log(`User entred input. (${uname} and ${key} )`);
    
    const options = {
        method: 'POST'
    };
    const response = await fetch(`https://localhost:5001/authenticate?UserName=${uname}&Password=${key}`, options);
    let data = await response.json();

    localStorage.setItem("token", JSON.stringify(data));

    const getToken = localStorage.getItem("token");
    const translateToken = JSON.parse(getToken);



    console.log(translateToken.token);

console.log(translateToken);


    
    
}

