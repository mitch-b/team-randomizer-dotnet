# Team Randomizer

Simple C# program within a Visual Studio Code [development container](https://code.visualstudio.com/docs/remote/containers).

.NET 5 console app uses Dependency Injection, making it an easy base to tinker from.

Jump to how it sorts into groups here in [`TestApp.cs`](./TestApp.cs#L46-L51). 

## How to Use

> Open this repository in VSCode with [Remote Development extension pack](https://aka.ms/vscode-remote/download/extension) installed. (See [Developing inside a Container](https://code.visualstudio.com/docs/remote/containers#_installation))

Edit [`people.txt`](./people.txt) as well as the number of groups you want them placed into in [`appsettings.json`](./appsettings.json#L12). 

Run the program using F5 in the VSCode devcontainer, and check the log and/or the `output.txt` file generated.

## Example

`people.txt` contains:

```text
Danial Paylor  
Arron Washer  
Georgeann Dehne  
Winifred Wisecarver  
Dawna Hollen  
Annelle Waddle  
Theresia Mulford  
Brandon Tao  
Mellissa Knaus  
Maybelle Brantner  
Vina Almon  
Hyman Anton  
Tamika Kepner  
Emanuel Pichette  
Issac Orton  
Mervin Trumbo  
Shiela Villalobos  
Mariam Hilchey  
Esmeralda Malek  
Raphael Neira  
Wilma Gillham  
Gita Bertucci  
Cathleen Soliz  
Jorge Capo  
Margot Michell  
Shila Congdon  
Carmon Dennard  
Bok Capello  
Eartha Richburg  
Ayanna Arvizu  
```

The output of this program will create (for example):

```text
> Group 1 ========
Danial Paylor  
Tamika Kepner  
Emanuel Pichette  
Eartha Richburg  
Ayanna Arvizu  

> Group 2 ========
Arron Washer  
Shiela Villalobos  
Mariam Hilchey  
Margot Michell  
Bok Capello  

> Group 3 ========
Brandon Tao  
Hyman Anton  
Mervin Trumbo  
Wilma Gillham  
Shila Congdon  

> Group 4 ========
Dawna Hollen  
Theresia Mulford  
Mellissa Knaus  
Maybelle Brantner  
Vina Almon  

> Group 5 ========
Winifred Wisecarver  
Annelle Waddle  
Issac Orton  
Cathleen Soliz  
Carmon Dennard  

> Group 6 ========
Georgeann Dehne  
Esmeralda Malek  
Raphael Neira  
Gita Bertucci  
Jorge Capo  
```