async function AddMovie() {

    let title = document.forms["addMovieForm"]["title"].value;
    let copies = document.forms["addMovieForm"]["copies"].value;
    let description = document.forms["addMovieForm"]["description"].value;

    const getToken = localStorage.getItem("token");
    const parseToken = JSON.parse(getToken);

    console.log(`User entred input. (${title} , ${copies} and ${description})`);
    
    const options = {
        method: 'POST',
        headers: {'Authorization': `Bearer ${parseToken.token}`}
    };
    fetch(`https://localhost:5001/api/Film?title=${title}&copies=${copies}&description=${description}`, options);
}

