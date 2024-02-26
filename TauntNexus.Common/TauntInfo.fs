namespace TauntNexus.Common

type TauntInfo = {
    FileIndex: int
    FileName: string
    AudioSource: AudioSource OrUnknown
    AudioDescription: AudioDescription option
}