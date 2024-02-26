namespace TauntNexus.Common

type OrUnknown<'t> = 
    | Known of 't
    | Unknown
    with 
        static member asOption orUnknown =
            match orUnknown with
            | Unknown -> None
            | Known v -> Some v

        static member ofOption opt =
            match opt with
            | None -> Unknown
            | Some v -> Known v
            
        static member map fn = function | Unknown -> Unknown | Known v -> Known (fn v)
        static member bind fn = function | Unknown -> Unknown | Known v -> (fn v)

type AudioSourceTags = 
    | AudioTags of Map<string, string>
    with
        static member empty = AudioTags Map.empty
        static member change fn (AudioTags tags) = AudioTags (fn tags)
        static member add tag value = AudioSourceTags.change (Map.add tag value)
        static member remove tag = AudioSourceTags.change (Map.remove tag)

type SongInfo = 
    { title: string OrUnknown; artist: string OrUnknown }
    with
        static member create (title: string) (artist: string) = { title = Known title; artist = Known artist }
        static member changeTitle fn songInfo = { songInfo with title = fn songInfo.title }
        static member changeArtist fn songInfo = { songInfo with artist = fn songInfo.artist }

type AudioSourceType =
    | Other of string
    | TV of string
    | Movie of string
    | Game of string
    | Song of SongInfo


type AudioSource = 
    {
        sourceType: AudioSourceType
        tags: AudioSourceTags
    }
    with
        static member from source = { sourceType = source; tags = AudioSourceTags.empty }
        static member withTag (key, value) source = { source with tags = AudioSourceTags.add key value source.tags }
        static member withTags (tags: (string*string) list) source = List.fold (flip AudioSource.withTag) source tags
