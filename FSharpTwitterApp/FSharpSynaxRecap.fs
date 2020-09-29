module FSharpSyntaxRecap

//Bindin a value:
let x = 42

//binding a function:
let square x = x * x

//calling a function
let area = square x

//tuples
let t= 1,2
let a, b = t

// Printing to the console
printfn "the answer is %i" x

// discriminated union:
type Shape = 
| Square of side:float
| Rectangle of length:float * height:float
| Circle of radius:float

//Opening a namespace
open System

//Match statement
let Area(shape : Shape) = 
    match shape with
    |Square s -> s * s
    |Rectangle (l, h) -> l * h
    |Circle r -> Math.PI * r *r

//Record Types
type ScreenItem = 
    { Shape : Shape
      X : float
      Y : float
      CreatedAt: DateTime}

let shape1 = { Shape = Square 3.; X = 5.; Y = 4.; CreatedAt = DateTime.Now.AddDays(-2.)}
let shape2 = { Shape = Rectangle(2., 4.); X = 3.; Y = 5.; CreatedAt = DateTime.Now.AddDays(-1.)}
let shape3 = { Shape = Circle(9.2); X = 1.; Y = 6.; CreatedAt = DateTime.Now}

//Array Literal
let shapes = [|shape1; shape2; shape3|]

//Forward-piping
let ScreenItemsCreatedSince (since : DateTime) (items : ScreenItem[]) = 
    items
    |> Array.filter (fun item -> item.CreatedAt > since)
    |> Array.sortByDescending (fun item -> item.CreatedAt)

//custom operators
let (~~)x = float(x)

