// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open System
open Fake.Testing.Expecto


// --------------------------------------------------------------------------------------
// Build variables
// --------------------------------------------------------------------------------------

let buildDir  = "./build/"
let appReferences = !! "/**/*.fsproj"
let dotnetcliVersion = "2.0.2"
let mutable dotnetExePath = "dotnet"

// --------------------------------------------------------------------------------------
// Helpers
// --------------------------------------------------------------------------------------

let run' timeout cmd args dir =
    if execProcess (fun info ->
        info.FileName <- cmd
        if not (String.IsNullOrWhiteSpace dir) then
            info.WorkingDirectory <- dir
        info.Arguments <- args
    ) timeout |> not then
        failwithf "Error while running '%s' with args: %s" cmd args

let run = run' System.TimeSpan.MaxValue

let runDotnet workingDir args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
    if result <> 0 then failwithf "dotnet %s failed" args

// --------------------------------------------------------------------------------------
// Targets
// --------------------------------------------------------------------------------------

Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "InstallDotNetCLI" (fun _ ->
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

Target "Restore" (fun _ ->
    appReferences
    |> Seq.iter (fun p ->
        let dir = System.IO.Path.GetDirectoryName p
        runDotnet dir "restore"
    )
)

Target "Build" (fun _ ->
    appReferences
    |> Seq.iter (fun p ->
        let dir = System.IO.Path.GetDirectoryName p
        runDotnet dir "build"
    )
)

Target "Rebuild" DoNothing

let runTests () =
    !! "Identification.Tests/bin/Debug/**/*.exe"
    |> Expecto id

Target "Test" (fun _ ->
    runTests ()
)
Target "Watch" (fun _ ->
    use watcher = !! "Identification.Tests/bin/Debug/**/*.exe" |> WatchChanges (fun changes -> 
        tracefn "%A" changes
        runTests()
    )

    System.Console.ReadLine() |> ignore //Needed to keep FAKE from exiting

    watcher.Dispose() // Use to stop the watch from elsewhere, ie another task.
)

// --------------------------------------------------------------------------------------
// Build order
// --------------------------------------------------------------------------------------

"Clean" ?=> "Build"
"Restore" ?=> "Build"

"InstallDotNetCLI"
    ==> "Restore"
    ==> "Rebuild"
"Clean" ==> "Rebuild"
"Build" ==> "Rebuild"

"Build" ==> "Test"

RunTargetOrDefault "Build"
