module Tests

open System
open Xunit
open PdfLibrary
open System.IO


[<Fact>]
let ``My test`` () =
    let spliter = PdfSpliter()
    let (ok, file) = spliter.TakePages("../../../../../resource/eng.pdf", 0,4)
    match ok with
    | true ->
        printfn "%A" file
        Assert.True(File.Exists file)
        File.Delete(file)
    | false ->
        Assert.True(false)
