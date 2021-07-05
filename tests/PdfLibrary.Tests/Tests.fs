module Tests

open System
open Xunit
open PdfLibrary
open System.IO

// [<Fact>]
// let ``My test`` () =
//     let spliter = PdfSpliter()
//     let (ok, file) = spliter.TakePages("../../../../../resource/eng.pdf", 0,4)
//     match ok with
//     | true ->
//         printfn "%A" file
//         Assert.True(File.Exists file)

//         File.Copy(file, "../../../../../resource/output/take.pdf")

//         File.Delete(file)
//     | false ->
//         Assert.True(false)


[<Fact>]
let GetPages() =
    let f = "../../../../../resource/eng.pdf"
    let count = PdfUtility.GetNumberOfPage(f)
    printfn "%A" count


[<Fact>]
let ``Replace`` () =
    let spliter = PdfSpliter()
    let org = "../../../../../resource/eng.pdf"
    let add = "../../../../../resource/output/take.pdf"

    let (ok, out) = spliter.ReplacePages(org, add, 0)

    out |> printfn "%s"
