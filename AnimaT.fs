﻿open FParsec.Primitives
open FParsec.CharParsers

let parserResult = run pfloat "1.2"

match parserResult with
| Success(result, _, _) ->
    printfn "(1) Result: %f" result
| Failure(_) ->
    ()

let parser1: Parser<string, unit> =
    preturn "Hello"
    >>= (fun s ->
        preturn (s + "!"))

match run parser1 "" with
| Success(result, _, _) ->
    printfn "(2) Result: %s" result
| Failure(_) ->
    ()

let identParser: Parser<string, unit> =
    IdentifierOptions(
        isAsciiIdStart = (fun c -> isAsciiLetter c || c = '_'),
        isAsciiIdContinue = fun c -> isAsciiLetter c || isDigit c || c = '_' || c = '\''
    )
    |> identifier

let parser2: Parser<string, unit> =
    pstring "let"
    >>. spaces1
    >>. identParser

match run parser2 "let _ = log 'hello'" with
| Success(result, _, _) ->
    printfn "(3) Result: %s" result
| Failure(_) ->
    ()
