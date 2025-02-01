type Address = {HouseNumber: int; StreetName: string}
type PhoneNumber = {Code: int; Number: string}

type ContactMethod =
    | PostalMail of Address
    | Email of string
    | VoiceMail of PhoneNumber

let sendMessage (message: string) (contactMethod: ContactMethod) =
    match contactMethod with
        | PostalMail { HouseNumber=h; StreetName = s} -> printfn $"Mailing {message} to {h} {s}"
        | Email e -> printfn $"Emailing {message} to {e}"
        | VoiceMail {Code=c;Number=n} -> printfn $"Left +{c}{n} a voicemail saying {message}"

let message = "Can't talk now, learning F#"

PostalMail {HouseNumber=1284; StreetName = "Elm Street"}
|> sendMessage message

Email "example@test.com"
|> sendMessage message

VoiceMail {Code = 92; Number="34798236"}
|> sendMessage message
