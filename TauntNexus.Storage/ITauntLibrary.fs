namespace TauntNexus.Storage
open TauntNexus.Common

type ITauntLibrary =
    abstract member allTaunts: unit -> TauntInfo seq
    abstract member addOrUpdate: TauntInfo -> Result<TauntInfo, string>
    abstract member count: int
