import { Cipher } from "./contracts/cipher";
import { PartialMessageEncoder } from "./contracts/implemented/partialMessageEncoder";
import { Language } from "./contracts/language";
import { MessageEncoder } from "./contracts/messageEncoder";

export class LanguageMessageEncoder<
L extends Language,
 C extends Cipher<L>>
    extends PartialMessageEncoder
    implements MessageEncoder {

    private totalEncodedCharacters = 0;
    private totalDecodedCharacters = 0;

    constructor(language: L,
                cipher: C) {
        super(language, cipher);
    }

    public encodeMessage(secretMessage: unknown): string {
        if (typeof secretMessage !== 'string'
            || secretMessage.length === 0) {
           return 'No message.';
        }


        const message = this.stripForbiddenSymbols(secretMessage);
        const isCompatible = this.language.isCompatibleToCharset(message);

        if (!isCompatible) {
            return 'Message not compatible.';
        }

        const encodedMessage = this.cipher.encipher(message);

        this.totalEncodedCharacters += message.length;

        return encodedMessage;
    }

    public decodeMessage(secretMessage: unknown): string {
        if (typeof secretMessage !== 'string'
            || secretMessage.length === 0) {
            return 'No message.';
        }

        const isCompatible = this.language.isCompatibleToCharset(secretMessage);

        if (!isCompatible) {
           return 'Message not compatible.';
        }

        const decodedMessage = this.cipher.decipher(secretMessage);

        this.totalDecodedCharacters += secretMessage.length;

        return decodedMessage;

    }

    public override totalProcessedCharacters(type: "Encoded" | "Decoded" | "Both"): string {
        let totalProcessedCharacters: number = 0;

        if (type === "Encoded") {
            totalProcessedCharacters = this.totalEncodedCharacters;
        }
        else if (type === "Decoded") {
            totalProcessedCharacters = this.totalDecodedCharacters;
        }
        else {
            totalProcessedCharacters = this.totalEncodedCharacters + this.totalDecodedCharacters;
        }

        return `Total processed characters count: ${totalProcessedCharacters}`
    }

     protected stripForbiddenSymbols(message: string) {
          let forbiddenSymbols = PartialMessageEncoder.forbiddenSymbols;
          forbiddenSymbols.forEach(x => message = message.replaceAll(x, ''));
          return message;
     }

}
