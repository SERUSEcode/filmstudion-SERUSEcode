async function AddMovie() {

    let title = document.forms["addMovieForm"]["title"].value;
    let copies = document.forms["addMovieForm"]["copies"].value;
    let description = document.forms["addMovieForm"]["description"].value;

    console.log(`User entred input. (${title} , ${copies} and ${description})`);
    
    const options = {
        method: 'POST'
    };
    fetch(`https://localhost:5001/api/Film?title=${title}&copies=${copies}&description=${description}`, options);
}

