# LS.Store

 Db design:
 
Categories -1---M-> Products
Customers -1---M-> Orders
Orders ---1---M-> OrderDetails
Orders ---1---1-> Invoice

Products -1---M-> Transactions


Customers -1---M-> Transactions

ProductInventory ---1---1-> Product
![enter image description here](https://i.yourimageshare.com/QLc99WukNx.webp)




## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Scaffolding

to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

