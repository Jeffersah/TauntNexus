namespace TauntNexus.Storage
open TauntNexus.Common

type FilesystemTauntLibrary (basePath: string) =
    let infoPath = System.IO.Path.Combine(basePath, "taunt_nexus.json")
