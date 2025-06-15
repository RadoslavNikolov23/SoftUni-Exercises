import { MonthsType, RoomNumbersType } from "./common";
import { Motel } from "./contracts/motel";
import { PartialMonthlyMotel } from "./contracts/partialMonthlyMotel";
import { Room } from "./contracts/room";

export class MonthlyMotel
            <T extends MonthsType> 
            extends PartialMonthlyMotel implements Motel{
    
    private totalBudget: number = 0;

    private roomsMap: Map<RoomNumbersType, Room> = new Map();
    private monthBookedMap: Map<RoomNumbersType, Set<T>> = new Map();

    public addRoom(room: unknown): string {
        
        if (this.isRoom(room) ) {
            const curRoomNumber = room.roomNumber;

            if (this.roomsMap.has(curRoomNumber)) {
                return `Room '${curRoomNumber}' already exists.`;
            }
            
            this.roomsMap.set(curRoomNumber, room);
            this.monthBookedMap.set(curRoomNumber, new Set<T>());
            
            return `Room '${curRoomNumber}' added.`;
        }

        return `Value was not a Room.`;
    }
    
    public bookRoom(roomNumber: RoomNumbersType, bookedMonth: T): string {
        
        if (!this.roomsMap.has(roomNumber)){

            return `Room '${roomNumber}' does not exist.`;
        } 

        const monthBookedCur = this.monthBookedMap.get(roomNumber)!;

        if (monthBookedCur != undefined && monthBookedCur.has(bookedMonth)) {
            return `Room '${roomNumber}' is already booked for '${bookedMonth}'`;
        }

        monthBookedCur.add(bookedMonth);
        this.totalBudget += this.roomsMap.get(roomNumber)!.totalPrice;
        return `Room '${roomNumber}' booked for '${bookedMonth}'.`;
    }
    
    public cancelBooking(roomNumber: RoomNumbersType, bookedMonth: T): string {

        if (!this.roomsMap.has(roomNumber)) {
            return `Room '${roomNumber}' does not exist.`;
        }

        const monthBookedCur = this.monthBookedMap.get(roomNumber);

        if (!monthBookedCur!.has(bookedMonth as T)) {
            return `Room '${roomNumber}' is not booked for '${bookedMonth}'.`;	
        }

        this.totalBudget -= this.roomsMap.get(roomNumber)!.cancellationPrice;
      
        monthBookedCur!.delete(bookedMonth);

        return `Booking cancelled for Room '${roomNumber}' for '${bookedMonth}'.`;
    }

    public override getTotalBudget(): string {
   
        return super.getTotalBudget() + `\n` +
               `Total budget: $${this.totalBudget.toFixed(2)}`;
    }

    private isRoom(obj: unknown): obj is Room {
        return typeof obj === 'object'
            && obj !== null
            && 'roomNumber' in obj
            && 'totalPrice' in obj
            && 'cancellationPrice' in obj;
      }
}

