const elementOutput = document.getElementById("output");

function OptionsGet() {
    const getToken = localStorage.getItem("token");
    const parseToken = JSON.parse(getToken);

    const options = {
        method: 'GET',
        headers: {'Authorization': `Bearer ${parseToken.token}`}
    };

    return options;
}

async function GetFilms() {

    const response = await fetch(`https://localhost:5001/api/Film`, OptionsGet());
    let data = await response.json();

    return data;
}

async function GetFilm(userInput) {
    
    const response = await fetch(`https://localhost:5001/api/Film/${userInput}`);
    let data = await response.json();

    return data;
}

async function SearchMovie() {
    let userInput = document.forms["searchFilmForm"]["searchFilm"].value;

    if(userInput == "") {
        PrintAllMovies();
        return;
    }

    let data = await GetFilm(userInput);

    ClearPage();

        
    const newP = document.createElement("p");
    const node = document.createTextNode(`ID: ${data.id}. Title: ${data.title}. Description: ${data.description}. Copies ${data.copies}`);
    newP.appendChild(node);

    elementOutput.appendChild(newP);
    
}

async function PrintAllMovies() {

    const data = await GetFilms();

    for (let i = 0; i < data.length; i++) {
        
        const newP = document.createElement("p");
        const node = document.createTextNode(`ID: ${data[i].id}. Title: ${data[i].title}. Description: ${data[i].description}. Copies ${data[i].copies}`);
        newP.appendChild(node);

        elementOutput.appendChild(newP);
        
    }

    console.log(data);

}

// function GetFilmById() {
//     const elementOutputIdMovie = document.getElementById("idMovie");

//     const data = GetFilms();

//     for (let i = 0; i < data.length; i++) {
        
//         const newOption = document.createElement("option");
//         const node = document.createTextNode(data[i].id);
//         const value = document.createV(data[i].id);
//         newOption.appendChild(node);

//         elementOutputIdMovie.appendChild(newOption);
        
//     }

// }

async function PrintFilmstudioById() {

    let userInput = document.forms["searchFilmstudioForm"]["searchFilmstudio"].value;

    const response = await fetch(`https://localhost:5001/api/Filmstudio/${userInput}`);
    let data = await response.json();

    ClearPage();

    const newP = document.createElement("p");
    const node = document.createTextNode(`ID: ${data.id}. Title: ${data.name}`);
    newP.appendChild(node);

    elementOutput.appendChild(newP);
}

async function PrintAllFilmstudio() {
    let userInput = document.forms["searchFilmstudioForm"]["searchFilmstudio"].value;

    const response = await fetch(`https://localhost:5001/api/Filmstudio`);
    let data = await response.json();

    for (let i = 0; i < data.length; i++) {
        
        const newP = document.createElement("p");
        const node = document.createTextNode(`ID: ${data[i].id}. Title: ${data[i].title}. Description: ${data[i].description}. Copies ${data[i].copies}`);
        newP.appendChild(node);

        elementOutput.appendChild(newP);
        
    }

}

// async function PrintUserByRole(role){

//     const response = await fetch(`https://localhost:5001/api/User`, OptionsGet());
//     let data = await response.json();

//     console.log(data);

//     for (let i = 0; i < data.length; i++) {

//         if (data[i].role == "FilmStudio")
//         {
//             const newP = document.createElement("p");
//             const node = document.createTextNode(`ID: ${data[i].id}. Role: ${data[i].role}. Username: ${data[i].userName}`);
//             newP.appendChild(node);

//             elementOutput.appendChild(newP);
//         }
//     }

//     console.log(data);
// }

function ClearPage() {
    elementOutput.innerHTML = ``;
}