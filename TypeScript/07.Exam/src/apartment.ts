import { RoomNumbersType } from "./common";
import { Room } from "./contracts/room";

export class Apartment implements Room{
    
    private readonly numberOfGuests: number;
    private readonly price: number;
    
    public readonly roomNumber: RoomNumbersType;

    constructor(price: number, roomNumber: RoomNumbersType, numberOfGuests: number) {
        this.price = price;
        this.roomNumber = roomNumber;
        this.numberOfGuests = numberOfGuests;
    }
    
    public get totalPrice(): number {
        return this.numberOfGuests * this.price;
    }

    public get cancellationPrice(): number {
        return this.totalPrice * 0.8;
    }

}
