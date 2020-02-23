export interface IApplicationType {
    environmentId: number;
    environmentName: string;
    environmentDescription?: string;
}

export class ApplicationType implements IApplicationType {
    constructor(
        public environmentId: number = null,
        public environmentName: string = '',
        public environmentDescription:string = '') { }
}