# calculator_service
 Service able to compute simple arithmetic operations
 Features:
 - Sum, subtract, multiply, divide and squareroot.
 - If *X-Evi-Tracking-Id* header is present, the operation is saved in memory cache.

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

## Command line client
The console application does HTTP requests to the API endpoints below.

