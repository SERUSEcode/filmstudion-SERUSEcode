async function AddMovie() {

    let title = document.forms["addMovieForm"]["title"].value;
    let copies = document.forms["addMovieForm"]["copies"].value;
    let description = document.forms["addMovieForm"]["description"].value;

    console.log(`User entred input. (${title} , ${copies} and ${description})`);
    
    const options = {
        method: 'POST',
        body: JSON.stringify({title, copies, description})
    };
    fetch(`https://localhost:5001/api/film`, options);
}