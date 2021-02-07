# rock-paper-scissors game
## net5.0 debian buster - tested on Firefox

## Contents

This repo contains 3 main folders

- Rock.Paper.Scissors
- Web
- images

## Rock.Paper.Scissors
The most important part of this exercise is under project Rock.Paper.Scissors. Entry point is the class called Game.cs. This project contains all the game logic.

## Web
Web project adds a reference to Rock.Paper.Scissors. Web project entry file is HomeController.cs which gets via dependency injection an instance of the Game class, the strategy to win and an instance of StatsCalculator class.

JavaScript logic for handling the view is inside Web/wwwroot/js/site.js.

## images
Finally the images folder contains screenshot shown bellow in this README.md file.

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
