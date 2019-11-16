export interface ITour {
    tourId: number;
    tourName: string;
    price: number;
}

export class Tour implements ITour {
    constructor(public tourId: number = null, public tourName: string = '', public price: number = null) { }
}