// async function RegisterUser() {

    

//     let uname = document.forms["formRegisterUser"]["uname"].value;
//     let key = document.forms["formRegisterUser"]["key"].value;
//     let isAdmin = document.forms["formRegisterUser"]["isAdmin"].value;

//     console.log(`User entred input. (${uname} , ${key} and ${isAdmin})`);

//     // const data = { 
//     //     id: 0,
//     //     username: uname,
//     //     password: key,
//     //     isAdmin: isAdmin
//     // };
    
//     const options = {
//         method: 'POST'
//     };
//     fetch(`https://localhost:5001/api/user?username=${uname}&password=${key}&isAdmin=${isAdmin}`, options);
// }

async function RegisterUser() {

    let uname = document.forms["formRegisterUser"]["uname"].value;
    let key = document.forms["formRegisterUser"]["key"].value;
    var isAdmin = document.getElementById('isAdminCheckBox').checked;

    console.log(`User entred input. (${uname} , ${key} and ${isAdmin})`);
    
    const options = {
        method: 'POST'
    };
    fetch(`https://localhost:5001/api/user?username=${uname}&password=${key}&isAdmin=${isAdmin}`, options);
}



