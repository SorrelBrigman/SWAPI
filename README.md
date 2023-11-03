# SWAPI
Accessing the SWAPI in for a code challenge.
See below for the code challenge requirements.

# How to run

Prereq: This project currently uses .NET 7.0 , please install on your computer if do not already have it.

Clone down this repo:
`git clone https://github.com/SorrelBrigman/SWAPI`

from your editor, install and update nuget packages if needed (most Visual Studio set up do this on build)

Run the project.

Running the project should open up your default browser to the project's swagger page.
If not you can navigate to it here: [https://localhost:7246/swagger/index.html]('https://localhost:7246/swagger/index.html')

You can interact with the endpoints via Swagger.


#End Points available"
All requests are GET requests.

## characters and their starships ###
<localhost>/api/SWAPI/person/starships
This endpoint returns the starships associated to Luke Skywalker.

<localhost>/api/SWAPI/person/starships/character_name
This endpoint, when coupled with the search param of name will return starships associated with the character_name you passed in, assuming it is a valid character name in star wars, and you spelled it correctly.

example use: (Character name "Darth Vader"
https://localhost:7246/api/SWAPI/person/starships/character_name?name=Darth%20Vader

## population of planets ##
<localhost>/api/SWAPI/population
This endpoint returns the sum of the population for all planets in the galaxy.

It should be noted that there are some planets with "unknown" population in the source data.  These planets, for the purpose of summation, are counted as having zero population.  So the reality is that the actually value of the population of all the planets in the galaxy summed together is likely much higher, we can only calculate what our data tells us.

## films and their species classifications ##
<localhost>/api/SWAPI/species/film
This endpoint returns all the species (name and classification) in The Phantom Menace (also known as First Episode).

<localhost>/api/SWAPI/species/film/film_title
This endpoint, when coupled with the search param of filmTitle will return all the species (name and classification) associated with the filmTitle you passed in, assuming it is a valid character film title in star wars, and you spelled it correctly.

example_use: (film title "A New Hope")
https://localhost:7246/api/SWAPI/species/film/film_title?filmTitle=A%20New%20Hope

#Shout out# 
to SharpTrooper by Olcay Bayram. I was unable to use the library directly (as it was on an older .NET version than my solution), but I strongly referenced this code for the SWAPI interaction code.



#Requirements of Code challenge:
# Requirements

1. Build a REST API to connect to the Star Wars API {https://swapi.dev/documentation#intro}

2. Include a readme on how to interact with the API

3. Include tests

## Endpoints to build

1. Return a list of the Starships related to Luke Skywalker

2. Return the classification of all species in the 1st episode

3. Return the total population of all planets in the Galaxy
