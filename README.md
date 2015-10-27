# WundergroundNetLib
[![Join the chat at https://gitter.im/MorphicDev/WundergroundNetLib](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/MorphicDev/WundergroundNetLib?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
## Description

A Wunderground wrapper for C# that provides a simple way to retrieve various data features from Wunderground personal weather stations (pws).

**Wunderground Data Features Currently Included in the Library:**

* Astronomy
* Conditions
* Forecast

## Using Your API Key
1. Get API key from Wunderground [here](http://www.wunderground.com/weather/api/d/docs) 
2. Navigate to the keys folder in the WundergroundNetLib solution
3. Add a text file to this folder called: WundergroundApiKey.txt
4. Add your Wunderground API key to this folder
5. In the properties of your solution ensure this file is included in the resources section
6. Your API key is available to you, but not anyone else

## TODO:
* Divide out TODO tasks into beginner, intermediate and advance
* Create DataInterpreter classes to help display the data in a more human readible format
* Add exception handling where needed
* Simplify DataProvider.GetData generic call, so you don't have to specify the data feature type twice.
* Populate PWS locations

## Advanced TODO:
* Integrate with a Travis CI, write tests for new features that newbies can develop against (Josh, I'm thinking of you).

## About Wunderground Personal Weather Stations

Weather Underground, provides real-time weather information via the Internet. Weather Underground's worldwide personal weather station network consists of weather enthusiasts who report live weather data to us from weather stations located on their houses or in their backyards.

[More info](http://www.wunderground.com/weatherstation/overview.asp)
