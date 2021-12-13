## Software required
* Visual Studio 2017 (Microsoft Imagine)
  * [Node.js](https://nodejs.org/)
  * npm (dolazi s Node.js-on)
  * Typescript (> ``npm install -g typescript``)
  * [.Net core](https://www.microsoft.com/net/download)
  * Sql server 
##### Doduše mislim da  instalacijom VS-a dolaze svi ostali programi


# Build proced
### Inicijalni korak je klonirati repozitorij
* > `win`+`r` powershell
* > `git` clone git@gitlab.com:nosredek/ctrlaltelite.git
### Kreiramo bazu podataka (CtrlAltElite.Entites project)
* > `cd` ctrlaltelite/src/CtrlAltElite.Web
* > `dotnet` ef database update
### Skidamo sve frontend knjižnice (project.json)
* > `npm` install
### Buildamo frontend (webpack.config.js)
* > `npm` run build
### Zadnje, build i start web servera
* > `dotnet` build
* > `dotnet` run 