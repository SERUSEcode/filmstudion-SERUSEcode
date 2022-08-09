**REST**
/authenticate (POST)
Kontrollera lösen och ge en token

/api/Film (GET)
Hämta alla filmer

/api/Film/{id} (GET)
Hämta en film med id

/api/Film (POST)
Skapa en ny film

/api/Film/{id} (PUT)
Updatera en film med information. (Behöver bara vara id och en annan ruta så som title, description och mera)

/api/Filmstudio (Get)
Hämta alla filmstudior

/api/Filmstudio/{id} (Get)
Hämta en filmstudio med id

/api/Filmstudio/register (Post)
Skapa en ny användare

/api/User (Get)
Hämta alla användare

/api/User/register
Skapa en ny användare

**Säkerhet**
Dem säkerhets återgärder i min applikation är ganska låga. Först och främst så krypterar jag inte lösenordet innan jag skickar det ifrån klienten till servern. Vilket jag måste göra om applikation skulle gå live och fleratal personer skulle använda applikationen. Samma sak gäller med att varje gång man loggar in så skickas använarnamnet och lösenorder för att kolla om det är korrekt för att sedan retunera en nyckel. Vilket behöver samma kryptering

Inlogningen i användargränssnittet funkar på så sätt att jag skickar ett API anrop till autentiseringen med användarnamn och lösenord, kollar om det är korrekt. Är det korekt så skickar jag tillbaka en nyckel med information om rol, namnm, användarnamn, token och när token går ut. Sedan sparar jag token på localstoradge. Jag vet att detta är ett väldigt osäkert sätt att spara nyckeln på. Jag borde egentligen spara den i minet utan maskinen. Men jag kände att funktionaliteten var den viktiga biten och dem tänksiska sakerna kan jag återkomma till. 
Utloggningen funkar så att jag rensar localstoradge så försvinner nyckeln och där med blir utloggad. 


**Övrigt**
Jag han inte med i närheten av allt. Det som stoppade mig var först fetch mest med POST. Men även token autentiseringen stod ivägen. Jag lyckades aldrig implemitera en fungerande version med token autentisering. Men jag tror att problem är grundade i att jag aldrig har använt interface tidigare och var nu tvungen att använda det. Vilket tog nästa halva vecka att förstå.