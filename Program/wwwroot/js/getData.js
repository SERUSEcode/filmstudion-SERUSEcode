const elementOutput = document.getElementById("output");


async function GetFilms() {
    const response = await fetch('https://localhost:5001/api/Film');
    let data = await response.json();

    return data;
}

async function GetFilm(userInput) {
    const response = await fetch(`https://localhost:5001/api/film/${userInput}`);
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

    let data = await GetFilms();

    for (let i = 0; i < data.length; i++) {
        
        const newP = document.createElement("p");
        const node = document.createTextNode(`ID: ${data[i].id}. Title: ${data[i].title}. Description: ${data[i].description}. Copies ${data[i].copies}`);
        newP.appendChild(node);

        elementOutput.appendChild(newP);
        
    }

    console.log(data);

}

function GetFilmById() {
    const elementOutputIdMovie = document.getElementById("idMovie");

    const data = GetFilms();

    for (let i = 0; i < data.length; i++) {
        
        const newOption = document.createElement("option");
        const node = document.createTextNode(data[i].id);
        const value = document.createV(data[i].id);
        newOption.appendChild(node);

        elementOutputIdMovie.appendChild(newOption);
        
    }

}

function ClearPage() {
    elementOutput.innerHTML = ``;
}