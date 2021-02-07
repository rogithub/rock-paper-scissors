# rock-paper-scissors game
## net5.0 debian buster - tested on Firefox

## Run

``` bash
$ git clone git@github.com:rogithub/rock-paper-scissors.git
$ cd rock-paper-scissors/Web
$ dotnet run
```

## Open Browser 
[https://localhost:5001](https://localhost:5001)


## Playing
![playing](https://raw.githubusercontent.com/rogithub/rock-paper-scissors/main/images/game.png)


## Description

The most important part of this exercise is under project Rock.Paper.Scissors. Entry point is the class called Game.cs. This project contains all the game logic.

Web project adds a reference to Rock.Paper.Scissors. Web project entry file is HomeController.cs which gets via dependency injection an instance of Game class.

Finally the JavaScript logic for handling the view is inside Web/wwwroot/site.js.