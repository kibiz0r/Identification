module Identification.Tests

open Expecto
// open Expecto.Logging.Global
// open Expecto.Impl

[<EntryPoint>]
let main argv =
    let testPrinter : Expecto.Impl.TestPrinters = {
        beforeRun = fun _ -> async.Zero ()
        beforeEach = fun _ -> async.Zero ()
        info = fun _ -> async.Zero ()
        passed = fun _ _ -> async.Zero ()
        ignored = fun _ _ -> async.Zero ()
        failed = fun _ _ _ -> async.Zero ()
        exn = fun _ _ _ -> async.Zero ()
        summary = fun _ _ -> async.Zero ()
    }
    Tests.runTestsInAssembly defaultConfig argv
