const elementOutput = document.getElementById("output");

function ClearPage() {
    elementOutput.innerHTML = ``;
}

function OptionsPost() {
    const getToken = localStorage.getItem("token");
    const parseToken = JSON.parse(getToken);

    const options = {
        method: 'POST',
        headers: {'Authorization': `Bearer ${parseToken.token}`}
    };

    return options;
}

function OptionsPut() {
    const getToken = localStorage.getItem("token");
    const parseToken = JSON.parse(getToken);

    const options = {
        method: 'PUT',
        headers: {'Authorization': `Bearer ${parseToken.token}`}
    };

    return options;
}



async function ChangeMovie() {

    let id = document.forms["form"]["id"].value;
    let title = document.forms["form"]["title"].value;
    let copies = document.forms["form"]["copies"].value;
    let description = document.forms["form"]["description"].value;
    
    const response = await fetch(`https://localhost:5001/api/Film/${id}?title=${title}&copies=${copies}&description=${description}`, OptionsPut());

}