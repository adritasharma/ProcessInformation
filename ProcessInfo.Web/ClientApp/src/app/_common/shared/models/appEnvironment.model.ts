export interface IAppEnvironment {
    environmentId: number;
    environmentName: string;
    environmentDescription?: string;
}

export class AppEnvironment implements IAppEnvironment {
    constructor(
        public environmentId: number = null,
        public environmentName: string = '',
        public environmentDescription:string = '') { }
}