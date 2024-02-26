module TauntNexus.Common

let inline flip fn a b = fn b a

let inline tup a b = (a, b)
let inline tup3 a b c = (a, b, c)

let inline mapFst fn (a, b) = (fn a, b)
let inline mapSnd fn (a, b) = (a, fn b)

let inline flipTup (a, b) = (b, a)
