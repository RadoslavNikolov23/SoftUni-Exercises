import { Language } from "./contracts/language";
import { DnaBases } from "./types";

export class DNACodeLanguage implements Language{
    
    private _charset: Set<DnaBases> = new Set(['A', 'C', 'G', 'T']);

    get charset() {
        return this._charset;
    }

    isCompatibleToCharset(message: string): boolean {
         const messageChars = message.split('');
        const allowedChars: string[] = Array.from(this.charset.values());
        const isCompatible = messageChars.every(ch => allowedChars.includes(ch));
        return isCompatible;
       
        // let allChars = message.split('');
       // let isCompatible = allChars.every(x => this.charset.forEach(i=>i===x));
        //return isCompatible;


         //return [...message].every(char => this.charset.has(char as DnaBases));
    }

}



