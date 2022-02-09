// var urlPostNewMovie = "https://localhost:5001/api/film";

// var httpRequest = (HttpWebRequest)WebRequest.Create(urlPostNewMovie);
// httpRequest.Method = "POST";


async function addMovie() {


    let title = document.forms["addMovieForm"]["title"].value;
    let copies = document.forms["addMovieForm"]["copies"].value;
    let description = document.forms["addMovieForm"]["description"].value;

    console.log(`User entred input. (${title} , ${copies} and ${description})`);

    // const data = {
    //     "title": title,
    //     "copies": copies,
    //     "description": description
    // };

    // app.post('api/film/AddFilm', (request, response) => {
    //     console.log(request);
    // });

}