# calculator_service
 Service able to compute simple arithmetic operations
 Features:
 - Sum, subtract, multiply, divide and squareroot.
 - If *X-Evi-Tracking-Id* header is present, the operation is saved in memory cache.

# Enviroment and assumptions
- .Net Core 3.1 has being used as the base of this solution
- Int32 variables for most of the properties, except for squareroot operations.
- As journal is only needed to be kept for the duration of the application, I have used memory cache. (*Microsoft.Extensions.Caching.Memory.IMemoryCache*)
- Design patterns such as command/query segregation, singletons,...
- Programming principles such as SOLID and TDD.
- Logging requests middleware.

# How to run
## REST Api application
### Swagger
Just run the application (F5) with CalculatorService.Server as Startup project and go to http://localhost:4631/swagger/index.html

### Docker
- Install Docker

[https://www.docker.com/docker-community](https://www.docker.com/docker-community)

- Run the following commands in .\src\CalculatorService.Server folder:
```
$ dotnet publish
$ docker build -t calculatorservice.server .
$ docker run -p 4631:80 calculatorservice.server
```

### API Request: use curl, Postman, or CLI (instructions provided below)

- Sum two or more values
```http
POST /calculator/add
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `addends`      | `int[]` | **Required**. Addends to sum |

- Difference between a minuend and a subtrahend
```http
POST /calculator/sub
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `minuend`      | `int` | **Required**. Minuend |
| `subtrahend`      | `int` | **Required**. Subtrahend |

- Multiply two or more values
```http
POST /calculator/mult
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `factors`      | `int[]` | **Required**. Factors to multiply |

- Divide dividend and divisor. Retrieving quotient and remainder
```http
POST /calculator/div
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `dividend`      | `int` | **Required**. Dividend |
| `divisor`      | `int` | **Required**. Divisor |

- Square root of given number
```http
POST /sqrt
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `number`      | `int` | **Required**. Number to get its square root |

- Retrieves operations associated with its *X-Evi-Tracking-Id* header
```http
POST /journal/query
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Key to find operations |

## Command line client (*CalculatorService.Client*)
The console application does HTTP requests to the API endpoints below.

| Parameter | Description							| Example			|
| :-------- | :--------------------------------		| :---------------	|
| `-o`      | **Required**. Operation type			|`-o "add"|
| `-p`      | **Required**. Operation parameters	|`-p 1+2+3+4+5`|
| `-x`      | Tracking identifier					|`-x "trackId123"`|

### CLI examples
| Type      | Description                   | Example              |
| :------   | :---------------------------  | :--------------------|
| `add`     | Sum two or more values        |`-o "add" -p 1+2+3+4+5`        |
| `sub`     | Minuend minus subtrahend      |`-o "sub" -p 10-4`          |
| `mult`    | Multiply two or more values   |`-o "mult" -p 1*2*3*4*5`|
| `div`     | Dividend divide divisor      |`-o "div" -p 10/4`|
| `sqrt`    | Squareroot of a number       |`-o "sqrt" -p 4`|
| `journal` | Operations of a tracking identifier |`-o "journal" -p "trackId123"` |