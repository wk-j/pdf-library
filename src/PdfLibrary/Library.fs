namespace PdfLibrary
open PdfSharp.Pdf.IO
open PdfSharp.Pdf
open System.IO
open System

type PdfSpliter() =

    do
        Windows874.Windows874.Register()

    member this.TakePages(filePath: string, startPage, endPage) =

        let tempPath = Path.GetTempPath()
        let tempName = Guid.NewGuid().ToString("N") + ".pdf"

        let temp = Path.Combine(tempPath, tempName)
        let input = PdfReader.Open(filePath, PdfDocumentOpenMode.Import)
        let count = input.PageCount

        if (count > startPage && count > endPage) |> not then
            (false, "")
        else
            let output = new PdfDocument()
            for i in startPage .. endPage do
                let page = input.Pages.[i]
                output.AddPage(page) |> ignore

            output.Save(temp)
            (true, temp)