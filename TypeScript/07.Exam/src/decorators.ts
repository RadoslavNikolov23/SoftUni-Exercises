export function decorator1( constructor:Function) {}

export function decorator2(target: any, propertyName: string, descriptor: PropertyDescriptor) {
    const originalDescriptor = descriptor.get;

    descriptor.get = function() {
        return originalDescriptor?.call(this) * 1.2; 
    };

    return descriptor;
}

export function decorator3(target: any, propertyName: string, descriptor: PropertyDescriptor) {
    const originalDescriptor = descriptor.get;

    descriptor.get = function() {
        return originalDescriptor?.call(this) * 1.2; 
    };

    return descriptor;
}

export function decorator4(target:any, parameterName:string, index:number) {}

export function decorator5<T extends abstract new (...args:any[])=> {} > (constructor: T) {
    abstract class ExtendedPartialMonthlyMotel extends constructor {
        public static readonly MotelName = 'Monthly Motel';
    }

    return ExtendedPartialMonthlyMotel;
}
