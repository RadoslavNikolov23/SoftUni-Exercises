"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LanguageMessageEncoder = void 0;
const partialMessageEncoder_1 = require("./contracts/implemented/partialMessageEncoder");
class LanguageMessageEncoder extends partialMessageEncoder_1.PartialMessageEncoder {
    totalEncodedCharacters = 0;
    totalDecodedCharacters = 0;
    constructor(language, cipher) {
        super(language, cipher);
    }
    encodeMessage(secretMessage) {
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
    decodeMessage(secretMessage) {
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
    totalProcessedCharacters(type) {
        let totalProcessedCharacters = 0;
        if (type === "Encoded") {
            totalProcessedCharacters = this.totalEncodedCharacters;
        }
        else if (type === "Decoded") {
            totalProcessedCharacters = this.totalDecodedCharacters;
        }
        else {
            totalProcessedCharacters = this.totalEncodedCharacters + this.totalDecodedCharacters;
        }
        return `Total processed characters count: ${totalProcessedCharacters}`;
    }
    stripForbiddenSymbols(message) {
        let forbiddenSymbols = partialMessageEncoder_1.PartialMessageEncoder.forbiddenSymbols;
        forbiddenSymbols.forEach(x => message = message.replaceAll(x, ''));
        return message;
    }
}
exports.LanguageMessageEncoder = LanguageMessageEncoder;
//# sourceMappingURL=languageMessageEncoder.js.map