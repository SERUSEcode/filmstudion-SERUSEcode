**REST**
api/user/register (POST)
Registrerar en ny användare

api/film (GET)
Hämtar alla filmer

api/film/{id} (GET)
Hämtar alla filmer

api/film/AddFilm (POST)
Skapar en ny film

**Säkerhet**
Jag fick aldrig till token autentisering. Men min tanke var att att den skicka skickas med och sprasas lokalt på användargränsnittet. För att sedan skicka till servern när det behövs autentisera. 


**Övrigt**
Jag han inte med i närheten av allt. Det som stoppade mig var först fetch mest med POST. Men även token autentiseringen stod ivägen. Jag lyckades aldrig implemitera en fungerande version med token autentisering. Men jag tror att problem är grundade i att jag aldrig har använt interface tidigare och var nu tvungen att använda det. Vilket tog nästa halva vecka att förstå.