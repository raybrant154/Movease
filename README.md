# Movease

### Keeping track of your _**Movies**_ has never been easier with _**Movease**_!

## How to download:

Feel free to clone!!

1. First, since this is a C# project, make sure you have Visual Studio Community downloaded on a Windows computer or bootcamped Mac
2. Click green "Code" button with dropdown list
3. Copy the GitHub link
4. Open your terminal
5. Navigate to the directory you'd like to clone the project
6. Once in directory, type "git clone" then paste the URL you copied in step 2
7. Press enter and your local clone will be created

## How to run Movease:

1. Once cloned, open the project in Visual Studio Community
2. Open Postman
3. In Visual Studio Community, press the play "IIS Express" button and a new window will open in your internet browser
4. Once opened, navigate to "API" in the NavBar
5. On the API page, you will find documentation with all the viable endpoints
6. Copy the localhost url and paste in a new request on Postman
7. On API page, click on each endpoint to find body keys needed for Postman testing

#### Account Class

1. Use this class to register a new account and get a token
2. Do a GET request with "/token" at the end of your url to get the token needed to use the rest of the classes
3. After getting token, navigate to the Headers tab and add "Authorization" key and in the value add "bearer yourTokenHere"

#### User Class

Use this class to register multiple users under one account. Comes with full CRUD capabilities.

#### Movie Class

Use this class to do full CRUD with a single movie

#### Movie Collection Class

Use this class to create multiple collections of various movies. Comes with full CRUD capabilities.

#### Movie On List Class

Use this class to add movies to a collection. Comes with full CRUD capabilities

## Resources used:

http://www.omdbapi.com/

https://stackoverflow.com/

https://www.linkedin.com/in/casey-wilson-84a99a111/

https://www.linkedin.com/in/marquese-martin-hayes-jr-a33b0574/

https://www.linkedin.com/in/joshualtucker/

https://www.linkedin.com/in/michael-pabody/

## Made by:

Brant Ray

https://www.linkedin.com/in/brant-ray-67a525182/

Slayde Settle

https://www.linkedin.com/in/slayde-settle-b9547769/

Wes Winn

https://www.linkedin.com/in/wes-winn-90b74678/ 
