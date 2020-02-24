export interface IUser {
    userId: string;
    firstName: string;
    lastName: string;
    fullName: string;
    password: string;
}

export class User implements IUser {
    constructor(
        public userId: string = '',
        public password: string = '',
        public firstName: string = '',
        public fullName: string = '',
        public lastName: string = '',
    ) { }
}